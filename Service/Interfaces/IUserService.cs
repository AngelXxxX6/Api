using Domain.Enitity;

namespace Service.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<bool> CreateAsync(UserViewModel user);
        Task<bool> DeleteByIdAsync(int id);
        Task<bool> UpdateByIdAsync(int id, UserViewModel user);
        Task<User> GetByIdAsync(int id);
    }
}
