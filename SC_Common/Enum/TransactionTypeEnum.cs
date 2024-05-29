using System.ComponentModel.DataAnnotations;

namespace SC_Common.Enum
{
    public enum TransactionTypeEnum
    {
        [Display(Name = "Cash Received")]
        CashReceived = 1,
        [Display(Name = "Expenses / Payments")]
        Expenses_Payments,
        [Display(Name = "IOU")]
        IOU,
        [Display(Name = "Bank")]
        Bank

    }
}
