using OrderPaymentPageApi.Data;
using OrderPaymentPageApi.Models;

namespace OrderPaymentPageApi.Repositories
{
    public class PaymentRepository:IRepository<Payment>,IPaymentUpdateRepository
    {
        OrderPaymentDbContext dbcontext;
        public PaymentRepository(OrderPaymentDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public void Add(Payment obj)
        {
            dbcontext.Payments.Add(obj);
            dbcontext.SaveChanges();
        }

        public List<Payment> GetAll()
        {
            return dbcontext.Payments.ToList();
        }

        public List<Payment> GetByClientId(int clientid)
        {
            return dbcontext.Payments.Where(payment => payment.ClientId == clientid).ToList();
        }

        public Payment GetById(int id)
        {
            return dbcontext.Payments.SingleOrDefault(payment => payment.Id == id);
        }

        
    }
}
