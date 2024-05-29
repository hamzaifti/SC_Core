using SC_Common.Dto;
using SC_Common.Model;

namespace SC_Service.Transactions
{
    public interface ITransactionService
    {
        Task<ResponseDto> DeleteTransaction(long id);
        Task<PagedResponseDto<Transaction>> GetAllTransactionsPaged(PagedRequestDto instance);
        Task<TransactionDateRangedResponse> GetTransactionByDateRange(DateTime startDate, DateTime endDate);
        Task<Transaction> GetTransactionById(long id);
        List<TransactionTypes> GetTransactionTypes();
        Task<ResponseDto> SaveTransaction(SaveTransactionDto instance);
    }
}
