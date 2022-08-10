using OrderPaymentPageApi.Models;
namespace OrderPaymentPageApi.Repositories
{
    public interface IPaymentUpdateRepository
    {
        public List<Payment> GetByClientId(int clientid);
    }
}
