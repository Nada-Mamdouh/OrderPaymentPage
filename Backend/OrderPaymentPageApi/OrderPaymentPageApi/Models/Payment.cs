using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OrderPaymentPageApi.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public double AmountPaid { get; set; }
        [ForeignKey("Client")]
        public int ClientId { get; set; }
        [JsonIgnore]
        public virtual Client? _Client { get; set; }
    }
}
