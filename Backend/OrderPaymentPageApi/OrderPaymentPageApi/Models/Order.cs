using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OrderPaymentPageApi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateOrdered { get; set; }
        public double ItemPrice { get; set; }
        public int Quantity { get; set; }
        public double Total { get; set; }
        public double PaidAmount { get; set; } = 0.0;
        [ForeignKey("_Client")]
        public int ClientId { get; set; }
        [JsonIgnore]
        public virtual Client? _Client { get; set; }
    }
}
