using OrderPaymentPageApi.Models;
namespace OrderPaymentPageApi.Repositories
{
    public interface IOrderUpdateRepository
    {
        public List<Order> GetByClientId(int clientid);
        public List<Order> orderByDate(List<Order> orders);
        public void deduct(double amount, List<Order> orderedOrdersByDate);
    }
}
