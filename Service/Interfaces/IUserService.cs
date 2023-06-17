
using Domain.Enitity;
using Domain.Response;

namespace Service.Interfaces
{
    public interface IUserService
    {
        Task<IBaseResponse<IEnumerable<User>>> GetUsers();
        Task<IBaseResponse<bool>> Create(UserViewModel user);
        Task<IBaseResponse<bool>> DeleteById(int id);
        Task<IBaseResponse<bool>> UpdateById(int id, UserViewModel user);

    }
}
