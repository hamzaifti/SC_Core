using Microsoft.EntityFrameworkCore;
using SC_Common.Dto;
using SC_Common.Model;
using SC_DBContext;

namespace SC_Service.IOU
{
    public class IouService : IIouService
    {
        private readonly ApplicationDBContext _context;

        public IouService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task DeleteIouReference(IouReference iouReference)
        {
            List<IouReference> completedRefs = await _context.IouReferences.Where(x => x.IouId == iouReference.IouId && x.IsDeleted == true).ToListAsync();
            completedRefs = completedRefs.Select(x => 
            {
                x.IsDeleted = false;
                return x;
            }).ToList();
            _context.IouReferences.Remove(iouReference);
            await _context.SaveChangesAsync();

        }

        public async Task<IouReference?> GetIouReferenceFromTransaction(long transactionId)
        {
            return await _context.IouReferences.FirstOrDefaultAsync(x => x.TransactionId == transactionId);
        }

        public async Task<List<IouReference>> GetIouReferences()
        {
            var iouReferences = await _context.IouReferences.ToListAsync();

            var groupedIouReferences = iouReferences
                .GroupBy(iou => iou.IouId)
                .Select(group => group.OrderByDescending(iou => iou.Id).First())
                .OrderByDescending(iou => iou.Id)
                .ToList();

            return groupedIouReferences;
        }

        private async Task DeleteCompletedIouReference(IouReference iouReferenceObj)
        {
            try
            {
                List<IouReference> iouReferences = await _context.IouReferences.Where(x => x.IouId == iouReferenceObj.IouId).ToListAsync();
                List<Transaction> transactions = await _context.Transactions.Where(x => iouReferences.Select(y => y.TransactionId).Contains(x.Id)).ToListAsync();

                if (transactions.Sum(x => x.Reciept) == transactions.Sum(x => x.Payment))
                {
                    iouReferences = iouReferences.Select(x =>
                    {
                        x.IsDeleted = true;
                        return x;
                    }).ToList();

                    await _context.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ResponseDto> SaveIouReference(IouReference iouReference)
        {
            try
            {


                IouReference? iouReferenceObj = await _context.IouReferences.FirstOrDefaultAsync(x => x.TransactionId == iouReference.TransactionId);

                if (iouReferenceObj != null)
                {
                    //in case of already completed iou reference undelete it so that it can be completed again
                    List<IouReference> iouReferences = await _context.IouReferences.Where(x => x.IouId == iouReferenceObj.IouId).ToListAsync();
                    iouReferences = iouReferences.Select(x =>
                    {
                        x.IsDeleted = false;
                        return x;
                    }).ToList();

                    _context.IouReferences.Remove(iouReferenceObj);
                    await _context.SaveChangesAsync();
                }

                iouReference.Id = 0;
                iouReference.IsDeleted = false;
                var iouRefEntry = await _context.IouReferences.AddAsync(iouReference);

                await _context.SaveChangesAsync();

                iouReference = iouRefEntry.Entity;

                await DeleteCompletedIouReference(iouReference);

                return new ResponseDto
                {
                    Success = true,
                    Message = "Reference Saved Successfully"
                };

            }
            catch (Exception)
            {
                return new ResponseDto
                {
                    Success = false,
                    Message = "Cannot Save Reference"
                };
            }

        }

        public async Task<List<PendingReferenceDto>> GetPendingIous(DateTime endDate)
        {
            try
            {
                List<IouReference> iouReferences = await _context.IouReferences.Where(x => x.IsDeleted == false).ToListAsync();
                List<Transaction> transactions = await _context.Transactions.Where(x => iouReferences.Select(y => y.TransactionId).Contains(x.Id) && x.CreatedOn.Date <= endDate.Date).OrderBy(x => x.CreatedOn).ToListAsync();
                iouReferences = iouReferences.Where(x => transactions.Select(y => y.Id).Contains(x.TransactionId)).ToList();
                List<Guid> processedIds = new();

                List<PendingReferenceDto> resultList = iouReferences.Select(x =>
                                                       {
                                                           if (processedIds.Any(y => y == x.IouId))
                                                           {
                                                               return new PendingReferenceDto
                                                               {
                                                                   Id = -1
                                                               };
                                                           }
                                                       
                                                           List<IouReference> ious = iouReferences.Where(y => y.IouId == x.IouId).ToList();
                                                       
                                                       
                                                           processedIds.Add(x.IouId);
                                                       
                                                           return new PendingReferenceDto
                                                           {
                                                               Id = x.Id,
                                                               IouId = x.IouId,
                                                               IsDeleted = x.IsDeleted,
                                                               TransactionId = x.TransactionId,
                                                               IouName = x.IouName,
                                                               TransactionDate = transactions.FirstOrDefault(y => y.Id == x.TransactionId)?.CreatedOn,
                                                               Role = transactions.FirstOrDefault(y => y.Id == x.TransactionId)?.Role ?? string.Empty,
                                                               Balance = transactions.Where(y => ious.Select(z => z.TransactionId).Contains(y.Id)).Sum(y => y.Payment ?? 0) - transactions.Where(y => ious.Select(z => z.TransactionId).Contains(y.Id)).Sum(y => y.Reciept ?? 0)
                                                           };
                                                       
                                                       }).ToList();

                return resultList.Where(x => x.Id != -1).ToList();


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
