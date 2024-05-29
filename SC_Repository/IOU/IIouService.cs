using SC_Common.Dto;
using SC_Common.Model;

namespace SC_Service.IOU
{
    public interface IIouService
    {
        Task<List<IouReference>> GetIouReferences();
        Task<ResponseDto> SaveIouReference(IouReference iouReference);
        Task DeleteIouReference(IouReference iouReference);
        Task<IouReference?> GetIouReferenceFromTransaction(long transactionId);
        Task<List<PendingReferenceDto>> GetPendingIous(DateTime endDate);

    }
}
