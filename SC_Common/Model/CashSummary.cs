using System.ComponentModel.DataAnnotations;

namespace SC_Common.Model
{
    public class CashSummary
    {
        [Key]
        public int Id { get; set; }
        public string Narration { get; set; }
        public double? PrecastCash { get; set; }
        public double? PaverCladCash { get; set; }
        public double? TotalCash { get; set; }
        public DateTime? TransactionDate { get; set; }
    }
}
