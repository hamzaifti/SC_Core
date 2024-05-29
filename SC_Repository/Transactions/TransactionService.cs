using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SC_Common.Dto;
using SC_Common.Enum;
using SC_Common.Model;
using SC_DBContext;
using SC_Service.CashSummaries;
using SC_Service.IOU;
using System.ComponentModel.DataAnnotations;

namespace SC_Service.Transactions
{
    public class TransactionService : ITransactionService
    {
        private readonly ApplicationDBContext _context;
        private readonly IIouService _iouService;
        private readonly ICashSummyService _cashSummyService;

        public TransactionService(ApplicationDBContext context,
                                  IIouService iouService,
                                  ICashSummyService cashSummyService
                                 )
        {
            _context = context;
            _iouService = iouService;
            _cashSummyService = cashSummyService;
        }

       


        public async Task<ResponseDto> SaveTransaction(SaveTransactionDto instance)
        {
            try
            {
                Transaction transaction = await _context.Transactions.FirstOrDefaultAsync(x => x.Id == instance.TransactionObj.Id) ?? new Transaction();

                if (transaction == null || transaction.Id == 0)
                {
                    var transactionEntry = await _context.Transactions.AddAsync(instance.TransactionObj);

                    await _context.SaveChangesAsync();

                    instance.TransactionObj = transactionEntry.Entity;

                    if (instance.IouReferenceObj != null)
                    {
                        instance.IouReferenceObj.TransactionId = instance.TransactionObj.Id;
                        await _iouService.SaveIouReference(instance.IouReferenceObj);
                    }



                    //changing balances
                    var result = await _context.Database.ExecuteSqlRawAsync("EXEC sp_ChangeBalance @InitialCreatedOn", new SqlParameter("@InitialCreatedOn", instance.TransactionObj.CreatedOn.ToString("yyyy-MM-dd HH:mm:ss")));

                    if (!Convert.ToBoolean(result) == true)
                    {
                        return new ResponseDto
                        {
                            Success = false,
                            Message = "Cannot Update Balance"
                        };
                    }

                    //saving in the bridge data
                    await _cashSummyService.SaveCashSummary(instance.TransactionObj);


                    return new ResponseDto
                    {
                        Success = true,
                        Message = "Transaction Added Successfully"
                    };
                }
                else
                {
                    var copyInstance = new Transaction
                    {
                        Id = instance.TransactionObj.Id,
                        CreatedOn = transaction.CreatedOn,
                        CreatedById = instance.TransactionObj.CreatedById,
                        CreatedByName = instance.TransactionObj.CreatedByName,
                        TransactionType = instance.TransactionObj.TransactionType,
                        Balance = instance.TransactionObj.Balance,
                        Role = instance.TransactionObj.Role,
                        Particular = instance.TransactionObj.Particular,
                        RecieptNo = instance.TransactionObj.RecieptNo,
                        Reciept = instance.TransactionObj.Reciept,
                        Payment = instance.TransactionObj.Payment
                    };
                    _context.Entry(transaction).CurrentValues.SetValues(copyInstance);
                    await _context.SaveChangesAsync();
                    
                    if (instance.IouReferenceObj != null)
                    {
                        instance.IouReferenceObj.TransactionId = copyInstance.Id;
                        await _iouService.SaveIouReference(instance.IouReferenceObj);
                    }

                    //changing balances
                    var result = await _context.Database.ExecuteSqlRawAsync("EXEC sp_ChangeBalance @InitialCreatedOn", new SqlParameter("@InitialCreatedOn", transaction.CreatedOn.ToString("yyyy-MM-dd HH:mm:ss")));

                    if (Convert.ToBoolean(result) == false)
                    {
                        return new ResponseDto
                        {
                            Success = false,
                            Message = "Cannot Update Balance"
                        };
                    }

                    await _context.SaveChangesAsync();


                    return new ResponseDto
                    {
                        Success = true,
                        Message = "Transaction Updated Successfully"
                    };

                }

            }
            catch (Exception ex)
            {
                return new ResponseDto
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        public List<TransactionTypes> GetTransactionTypes()
        {
            List<TransactionTypes> transactionTypesList = new List<TransactionTypes>();

            foreach (TransactionTypeEnum enumValue in Enum.GetValues(typeof(TransactionTypeEnum)))
            {
                DisplayAttribute? displayAttribute = enumValue.GetType()
                                                              .GetMember(enumValue.ToString())[0]
                                                              .GetCustomAttributes(typeof(DisplayAttribute), false)
                                                              .FirstOrDefault() as DisplayAttribute;

                TransactionTypes transactionType = new TransactionTypes
                {
                    TransactionType = displayAttribute != null ? displayAttribute.Name : enumValue.ToString(),
                    TransactionValue = (int)enumValue
                };


                transactionTypesList.Add(transactionType);
            }

            return transactionTypesList;
        }

        public async Task<PagedResponseDto<Transaction>> GetAllTransactionsPaged(PagedRequestDto instance)
        {
            try
            {
                // Calculate the number of rows to take
                int takeCount = instance.EndRow - instance.StartRow + 1;

                // Apply pagination
                var query = _context.Transactions.AsQueryable();

                int filterTextTotalRows = 0;

                // Apply filtering based on start and end indices
                if (!string.IsNullOrEmpty(instance.FilterText))
                {
                    string filterText = instance.FilterText.Trim().ToLower();
                    query = query.Where(x =>
                                            (x.Particular != null && x.Particular.ToLower().Contains(filterText)) ||
                                            x.CreatedByName != null && x.CreatedByName.ToLower().Contains(filterText) ||
                                            x.Reciept != null && x.Reciept.ToString().ToLower().Contains(filterText) ||
                                            x.RecieptNo != null && x.RecieptNo.ToLower().Contains(filterText) ||
                                            x.Payment != null && x.Payment.ToString().ToLower().Contains(filterText)
                                        );

                    filterTextTotalRows = query.Count();

                }
                query = query.OrderByDescending(x => x.CreatedOn).Skip(instance.StartRow).Take(takeCount);

                // Execute the query and return the results
                var transactions = await query.ToListAsync();

                // Get the total count without applying filters
                var totalRows = string.IsNullOrEmpty(instance.FilterText) ? await _context.Transactions.CountAsync() : filterTextTotalRows;

                return new PagedResponseDto<Transaction>
                {
                    Data = transactions,
                    TotalRows = totalRows
                };
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<Transaction> GetTransactionById(long id)
        {
            try
            {
                return await _context.Transactions.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ResponseDto> DeleteTransaction(long id)
        {
            try
            {
                var transaction = await _context.Transactions.FirstOrDefaultAsync(x => x.Id == id);
                if (transaction != null)
                {
                    _context.Transactions.Remove(transaction);
                    await _context.SaveChangesAsync();

                    IouReference? iouReference = await _context.IouReferences.FirstOrDefaultAsync(x => x.TransactionId == id);
                    
                    if(iouReference != null)
                    {
                        await _iouService.DeleteIouReference(iouReference);
                    }

                    //changing balances
                    var result = await _context.Database.ExecuteSqlRawAsync("EXEC sp_ChangeBalance @InitialCreatedOn", new SqlParameter("@InitialCreatedOn", transaction.CreatedOn.ToString("yyyy-MM-dd HH:mm:ss")));


                    return new ResponseDto
                    {
                        Success = true,
                        Message = "Transaction Deleted"
                    };
                }
                else
                {
                    return new ResponseDto
                    {
                        Success = false,
                        Message = "Tranasaction Already Deleted"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseDto
                {
                    Success = false,
                    Message = "Something Went Wrong, Can't delete"
                };
            }
        }

        private async Task<List<CashSummaryDto>> GetCashSummary(DateTime dateObj)
        {
            string[] narrationArr = { "h.o", "factory", "fsd shop", "sgd shop", "bank" };




            List<CashSummaryDto> cashSummaries = new();

            List<Transaction> transactions = new();
            List<Transaction> transactionsFiltered = await _context.Transactions.Where(x => x.CreatedOn.Date <= dateObj.Date).ToListAsync();

            foreach (var narration in narrationArr)
            {

                CashSummaryDto cashSummary = new();

                switch (narration.ToLower())
                {
                    case "h.o":
                        transactions = transactionsFiltered.Where(x => x.Role.ToLower().Contains("h.o") && x.CreatedOn.Date <= dateObj.Date).ToList();
                        cashSummary.Narration = "H.O";
                        break;
                    case "factory":
                        transactions = transactionsFiltered.Where(x => x.Role.ToLower().Contains("site") && x.CreatedOn.Date <= dateObj.Date).ToList();
                        cashSummary.Narration = "Factory";
                        break;
                    case "fsd shop":
                        transactions = transactionsFiltered.Where(x => x.Role.ToLower().Contains("fsd shop") && x.CreatedOn.Date <= dateObj.Date).ToList();
                        cashSummary.Narration = "FSD Shop";
                        break;
                    case "sgd shop":
                        transactions = transactionsFiltered.Where(x => x.Role.ToLower().Contains("sgd shop") && x.CreatedOn.Date <= dateObj.Date).ToList();
                        cashSummary.Narration = "SGD Shop";
                        break;
                    case "bank":
                        transactions = transactionsFiltered.Where(x => x.TransactionType == (int)TransactionTypeEnum.Bank && x.CreatedOn.Date <= dateObj.Date).ToList();
                        cashSummary.Narration = "Bank Balance";
                        break;

                }


                if (transactions != null)
                {
                    cashSummary.PrecastCash = transactions.Where(x => x.Role != null && x.Role.ToLower().Contains("precast"))
                        .Sum(x => x.Reciept ?? 0) - transactions.Where(x => x.Role != null && x.Role.ToLower().Contains("precast"))
                        .Sum(x => x.Payment ?? 0);
                    cashSummary.PaverCladCash = transactions.Where(x => x.Role != null && x.Role.ToLower().Contains("paver"))
                        .Sum(x => x.Reciept ?? 0) - transactions.Where(x => x.Role != null && x.Role.ToLower().Contains("paver"))
                        .Sum(x => x.Payment ?? 0);
                }
                else
                {
                    cashSummary.PrecastCash = 0;
                    cashSummary.PaverCladCash = 0;
                }

                if (narration.ToLower() == "bank" && transactions != null)
                {
                    cashSummary.TotalCashInHand = transactions.Sum(x => x.Reciept ?? 0) - transactions.Sum(x => x.Payment ?? 0);
                }
                else if (narration.ToLower() == "fsd shop" && transactions != null)
                {
                    cashSummary.TotalCashInHand = transactions.Sum(x => x.Reciept ?? 0) - transactions.Sum(x => x.Payment ?? 0);
                }
                else
                {
                    cashSummary.TotalCashInHand = cashSummary.PrecastCash + cashSummary.PaverCladCash;
                }

                cashSummaries.Add(cashSummary);
            }

            return cashSummaries;
        }

        public async Task<TransactionDateRangedResponse> GetTransactionByDateRange(DateTime startDate, DateTime endDate)
        {
            try
            {
                TransactionDateRangedResponse res = new();
                List<Transaction> rangedTransactions = await _context.Transactions.Where(x => x.CreatedOn.Date >= startDate.AddDays(1).Date && x.CreatedOn.Date <= endDate.Date).ToListAsync();
                res.Transactions = rangedTransactions;
                if (rangedTransactions.Count > 0)
                {
                    res.ClosingBalance = (double)rangedTransactions.OrderByDescending(x => x.CreatedOn).FirstOrDefault().Balance;
                }
                else
                {
                    res.ClosingBalance = 0;
                }
                Transaction openingTransaction = new Transaction();
                if (_context.Transactions.Any(x => x.CreatedOn.Date <= startDate.Date))
                {
                    openingTransaction = await _context.Transactions.Where(x => x.CreatedOn.Date <= startDate.Date).OrderByDescending(x => x.CreatedOn).FirstOrDefaultAsync() ?? new Transaction();
                    res.OpeningBalance = openingTransaction?.Balance ?? 0;
                }
                else
                {
                    res.OpeningBalance = 0;
                }


                res.CashSummaryReportList = new List<CashSummaryReportDto>()
                {
                    new CashSummaryReportDto()
                    {
                        CashSummaryList = await GetCashSummary(startDate),
                        SummaryDate = startDate,
                    },
                    new CashSummaryReportDto()
                    {
                        CashSummaryList = await GetCashSummary(endDate),
                        SummaryDate = endDate
                    }
                };

                res.PendingIouList = await _iouService.GetPendingIous(endDate);


                return res;


            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
