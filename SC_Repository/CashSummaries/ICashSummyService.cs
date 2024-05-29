using SC_Common.Dto;
using SC_Common.Model;

namespace SC_Service.CashSummaries
{
    public interface ICashSummyService
    {
        Task SaveCashSummary(Transaction transaction);
        List<CashSummaryHeaderDto> GetCashSummaryHeaders();
    }
}
