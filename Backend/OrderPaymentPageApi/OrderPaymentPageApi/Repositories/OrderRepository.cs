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
            double orderPaidAmount = 0.0;
            foreach(var order in orderedOrdersByDate)
            {
                /** check if this row contains totally paid order */
                if (order.PaidAmount == order.Total) continue;

                /** check if this amount sent from user is equal to zero or a negative value
                 * in other iterations this variable will be decreased in each iteration 
                 * by the paid amount */
                else if (amount <= 0) break;

                /** if Total price of order is less than or equal to the amount sent 
                 * then we will store the difference between amount and orderPaidAmount in db */
                else if (order.Total <= amount)
                {
                    orderPaidAmount = amount - orderPaidAmount;
                }
                else 
                {
                /** else we will subtract the whole amount sent from user */
                    orderPaidAmount = amount;
                }
                /** making sure we won't subtract/deduct any money greater than total amount */
                orderPaidAmount = orderPaidAmount <= order.Total ? orderPaidAmount : order.Total;

                /** decreasing Total value by the paid amount */
                order.Total -= orderPaidAmount;

                /** decreasing amount sent from user by the paid (subtracted) amount in each row */
                amount -= orderPaidAmount;
                Order updatedorder = dbcontext.Orders.FirstOrDefault(or => or.Id == order.Id);
                /** making sure that paid amount from each order won't be greater than the total */
                if (updatedorder != null)
                {
                    try
                    {
                        updatedorder.Id = order.Id;
                        updatedorder.Title = order.Title;
                        updatedorder.ItemPrice = order.ItemPrice;
                        updatedorder.Quantity = order.Quantity;
                        updatedorder.Total = order.Total;
                        updatedorder.PaidAmount += orderPaidAmount;
                        dbcontext.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        // Console.WriteLine(ex.Message);
                        throw (ex);
                    }
                }
                

            }
        }

        
    }
}
