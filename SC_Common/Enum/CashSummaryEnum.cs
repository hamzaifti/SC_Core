using System.ComponentModel.DataAnnotations;

namespace SC_Common.Enum
{
    public enum CashSummaryEnum
    {
        [Display(Name = "H.O")]
        HO = 1,
        [Display(Name = "Factory")]
        Factory,
        [Display(Name = "FSD Shop")]
        FSDShop,
        [Display(Name = "SGD Shop")]
        SGDShop,
        [Display(Name = "Bank Balance")]
        BankBalance
    }
}
