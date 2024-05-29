using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC_Common.Dto
{
    public class CashSummaryDto
    {
        public string Narration { get; set; }
        public double PrecastCash { get; set; }
        public double PaverCladCash { get; set; }
        public double TotalCashInHand { get; set; }
    }

    public class CashSummaryReportDto
    {
        public List<CashSummaryDto> CashSummaryList { get; set; }
        public DateTime SummaryDate { get; set; }
    }
    public class CashSummaryHeaderDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
