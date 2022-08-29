using Microsoft.EntityFrameworkCore;
using OrderPaymentPageApi.Data;
using OrderPaymentPageApi.Models;

namespace OrderPaymentPageApi.Repositories
{
    public class OrderRepository:IRepository<Order>,IOrderUpdateRepository
    {
        OrderPaymentDbContext dbcontext;
        public OrderRepository(OrderPaymentDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public void Add(Order obj)
        {
            dbcontext.Orders.Add(obj);
            dbcontext.SaveChanges();
        }

        public List<Order> GetAll()
        {
            return dbcontext.Orders.ToList();
        }

        public Order GetById(int id)
        {
            return dbcontext.Orders.SingleOrDefault(order => order.Id == id);
        }
        public List<Order> GetByClientId(int clientid)
        {
            return dbcontext.Orders.Where(order => order.ClientId == clientid).ToList();
        }
        public List<Order> orderByDate(List<Order> orders)
        {
            return orders.OrderBy(order => order.DateOrdered).ToList();
        }

        public void deduct(double amount, List<Order> orderedOrdersByDate)
        {
            double declinedAmount = amount;
            if (amount <= 0) return;
            else
            {
                List<Order> unpaidAndPartiallyPaidOrders = ordersOrderedByDate.Where(or => or.Total != or.PaidAmount).ToList();
                foreach (var order in unpaidAndPartiallyPaidOrders)
                {
                    double orderPaidAmount = 0.0;
                    double totallyPaidMoneyFromOrderSoFar = order.Total - order.PaidAmount;
                    if(declinedAmount < totallyPaidMoneyFromOrderSoFar)
                    {
                        orderPaidAmount = declinedAmount;
                    }
                    else
                    {
                        orderPaidAmount = totallyPaidMoneyFromOrderSoFar;
                    }
                    declinedAmount -= orderPaidAmount;

                    /** Updating Paid Amount in each row and save the updated value to database */
                    order.PaidAmount += orderPaidAmount;
                    dbcontext.SaveChanges();
                }
            }
        }

        
    }
}
