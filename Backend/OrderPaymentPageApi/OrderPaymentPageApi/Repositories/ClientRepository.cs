using OrderPaymentPageApi.Data;
using OrderPaymentPageApi.Models;
namespace OrderPaymentPageApi.Repositories
{
    public class ClientRepository : IRepository<Client>
    {
        OrderPaymentDbContext dbcontext;
        public ClientRepository(OrderPaymentDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        //Add new Client:
        public void Add(Client client)
        {
            dbcontext.Clients.Add(client);
            dbcontext.SaveChanges();
        }
        //Read All Clients:
        public List<Client> GetAll()
        {
            return dbcontext.Clients.ToList();
        }

        //Read One Student By Id:
        public Client GetById(int id)
        {
            return dbcontext.Clients.SingleOrDefault(client => client.Id == id);
        }
        
    }
}
