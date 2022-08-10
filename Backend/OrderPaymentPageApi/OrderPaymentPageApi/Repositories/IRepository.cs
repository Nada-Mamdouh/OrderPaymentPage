namespace OrderPaymentPageApi.Repositories
{
    public interface IRepository<T>
    {
        void Add(T obj);
        List<T> GetAll();
        T GetById(int id);
    }
}