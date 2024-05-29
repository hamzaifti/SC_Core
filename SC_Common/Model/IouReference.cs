
using System.ComponentModel.DataAnnotations;

namespace SC_Common.Model
{
    public class IouReference
    {
        [Key]
        public int Id { get; set; }
        public Guid IouId { get; set; }
        public string IouName { get; set;}
        public long TransactionId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
