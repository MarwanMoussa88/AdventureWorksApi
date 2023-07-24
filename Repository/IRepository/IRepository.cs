using AdventureWorksAPI.Models;

namespace AdventureWorksAPI.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetOne(int id);
        T Update(T entity );
        T Create(T entity);
        T Delete(T entity);
    }
}
