using SC_Common.Model;

namespace SC_Common.Dto
{
    public class TransactionDateRangedResponse
    {
        public List<Transaction> Transactions { get; set; }
        public double OpeningBalance { get; set; }
        public double ClosingBalance { get; set; }
        public List<CashSummaryReportDto> CashSummaryReportList { get; set; }
        public List<PendingReferenceDto> PendingIouList { get; set; }
    }
}
