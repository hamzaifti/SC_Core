using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SC_Common.Dto;
using SC_Common.Enum;
using SC_Common.Model;
using SC_DBContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC_Service.CashSummaries
{
    public class CashSummaryService : ICashSummyService
    {
        private readonly ApplicationDBContext _context;

        public CashSummaryService(ApplicationDBContext context)
        {
            _context = context;
        }

        public List<CashSummaryHeaderDto> GetCashSummaryHeaders()
        {
            List<CashSummaryHeaderDto> cashSummaryHeaders = new List<CashSummaryHeaderDto>();

            foreach (CashSummaryEnum enumValue in Enum.GetValues(typeof(CashSummaryEnum)))
            {
                DisplayAttribute? displayAttribute = enumValue.GetType()
                                                              .GetMember(enumValue.ToString())[0]
                                                              .GetCustomAttributes(typeof(DisplayAttribute), false)
                                                              .FirstOrDefault() as DisplayAttribute;

                CashSummaryHeaderDto cashSummary = new CashSummaryHeaderDto
                {
                    Id = (int)enumValue,
                    Name = displayAttribute != null ? displayAttribute.Name : enumValue.ToString()
                };


                cashSummaryHeaders.Add(cashSummary);
            }

            return cashSummaryHeaders;
        }

        public async Task SaveCashSummary(Transaction transaction)
        {
            try
            {



                CashSummaryHeaderDto cashSummaryHeader = new CashSummaryHeaderDto();

                switch (transaction.Role.ToLower())
                {

                    case "paver (h.o)":
                    case "precast (h.o)":
                        cashSummaryHeader = GetCashSummaryHeaders().FirstOrDefault(x => x.Id == (int)CashSummaryEnum.HO) ?? new CashSummaryHeaderDto();
                        break;


                    case "paver (site)":
                    case "precast (site)":
                        cashSummaryHeader = GetCashSummaryHeaders().FirstOrDefault(x => x.Id == (int)CashSummaryEnum.Factory) ?? new CashSummaryHeaderDto();
                        break;


                    case "paver (sgd shop)":
                    case "precast (sgd shop)":
                        cashSummaryHeader = GetCashSummaryHeaders().FirstOrDefault(x => x.Id == (int)CashSummaryEnum.SGDShop) ?? new CashSummaryHeaderDto();
                        break;


                    case "fsd shop":
                        cashSummaryHeader = GetCashSummaryHeaders().FirstOrDefault(x => x.Id == (int)CashSummaryEnum.FSDShop) ?? new CashSummaryHeaderDto();
                        break;
                }


                await _context.Database.ExecuteSqlRawAsync("EXEC sp_BalanceSummary @CurrentTransDate, @Narration, @Amount, @Role",
                                                             new SqlParameter("@CurrentTransDate", transaction.CreatedOn.ToString("yyyy-MM-dd HH:mm:ss")),
                                                             new SqlParameter("@Narration", cashSummaryHeader.Name),
                                                             new SqlParameter("@Amount", (transaction.Reciept ?? 0) - (transaction.Payment ?? 0)),
                                                             new SqlParameter("@Role", transaction.Role)
                                                          );

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
