using Domain.Enitity;
using Domain.Response;

namespace Service.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();
        Task<bool> Create(UserViewModel user);
        Task<bool> DeleteById(int id);
        Task<bool> UpdateById(int id, UserViewModel user);
        Task<User> GetById(int id);
    }
}
