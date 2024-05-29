using SC_Common.Model;

namespace SC_Common.Dto
{
    public class SaveTransactionDto
    {
        public Transaction TransactionObj {  get; set; }
        public IouReference? IouReferenceObj { get; set; }
    }
}
