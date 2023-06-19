
namespace DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<bool> Create(T entity);
       

        IQueryable<T> Select();

        Task<bool> Delete(T entity);
        Task<bool> DeleteById(int id);
        Task<bool> Update(T entity);
    }
}
