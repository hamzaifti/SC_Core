using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC_Common.Model
{
    public class Transaction
    {
        [Key]
        public long Id { get; set; }
        public int TransactionType { get; set; }
        public string Role { get; set; }
        public string Particular { get; set; }
        public string? RecieptNo { get; set; }
        public double? Reciept { get; set; }
        public double? Payment {  get; set; }
        public double? Balance { get; set; }
        public string CreatedById { get; set; }
        public string CreatedByName { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
