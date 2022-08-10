using System.ComponentModel.DataAnnotations.Schema;

using OrderPaymentPageApi.Models;

namespace OrderPaymentPageApi.ViewModels
{
    [NotMapped]
    public class WalletViewModel
    {
        public double Debit { get; set; } = 0.0;
        public double Credit { get; set; } = 0.0;
        public double TotalPaidMoney { get; set; } = 0.0;
        public double NetMoneyOwed { get; set; } = 0.0;
        public double NetMoneyOwned { get; set; } = 0.0;
        public double WalletBalanceAfterDeduction { get; set; } = 0.0;
    }
}
