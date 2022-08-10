using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using OrderPaymentPageApi.ViewModels;
namespace OrderPaymentPageApi.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        [JsonIgnore]
        public virtual List<Order>? _Orders { get; set; }
        [JsonIgnore]
        public virtual List<Payment>? _Payments { get; set; }
        [JsonIgnore] 
        [NotMapped]
        public virtual WalletViewModel _wallet { get; set; }

    }
}
