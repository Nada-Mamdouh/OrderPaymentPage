using OrderPaymentPageApi.Data;
using OrderPaymentPageApi.Repositories;
using OrderPaymentPageApi.Models;
using OrderPaymentPageApi.ViewModels;
namespace OrderPaymentPageApi.Repositories
{
    public class WalletRepository 
    {
        OrderPaymentDbContext dbcontext;
        IRepository<Client> clientRepo;
        IRepository<Order> orderRepo;
        IRepository<Payment> paymentRepo;
        public WalletRepository(OrderPaymentDbContext dbcontext,
                                IRepository<Client> clientRepo, 
                                IRepository<Order> orderRepo, 
                                IRepository<Payment> paymentRepo)
        {
            this.dbcontext = dbcontext;
            this.clientRepo = clientRepo;
            this.orderRepo = orderRepo;
            this.paymentRepo = paymentRepo;

        }

        public void Update(List<Order> obj)
        {
            List<Order> ordersOrderedByDate = obj.OrderBy(obj => obj.DateOrdered).ToList();
        }

        public void Update(List<Payment> obj)
        {
            throw new NotImplementedException();
        }
        public List<Order> getOrdersByClientId(int clientId)
        {
            return dbcontext.Orders.Where(order => order.ClientId == clientId).ToList();
        }
        public List<Payment> getPaymentsByClientId(int clientId)
        {
            return dbcontext.Payments.Where(payment => payment.ClientId == clientId).ToList();
        }
        public double calculateCreditAmounts(List<Order> orders)
        {
            return orders.Sum(order => order.Total);
        }
        public double claculateDebitAmounts(List<Payment> payments)
        {
            return payments.Sum(payment => payment.AmountPaid);
        }
        public double calculateTotalPaidMoney(List<Order> orders)
        {
            return orders.Sum(order => order.PaidAmount);
        }
        public double calculateNetMoneyIowe(List<Order> orders)
        {
            double totalOrders = this.calculateCreditAmounts(orders);
            double totalPaidAmounts = this.calculateTotalPaidMoney(orders);
            return (totalOrders - totalPaidAmounts);  
        }
        public double calculateNetMoneyIown(List<Payment> payments,List<Order> orders)
        {
            double totalPayments = this.claculateDebitAmounts(payments);
            double totalPaidAmounts = this.calculateTotalPaidMoney(orders);
            return (totalPayments - totalPaidAmounts);
        }
    }
}
