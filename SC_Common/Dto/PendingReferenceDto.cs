using SC_Common.Model;

namespace SC_Common.Dto
{
    public class PendingReferenceDto: IouReference
    {
        public double Balance { get; set; }
        public string Role { get; set; }
        public DateTime? TransactionDate { get; set; }
    }
}
