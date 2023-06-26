
namespace DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<bool> Create(T entity);

        Task<IEnumerable<T>> Select();

        Task<T> GetById(int id);

        Task<bool> Delete(T entity);

        Task<bool> Update(T entity);
    }
}
