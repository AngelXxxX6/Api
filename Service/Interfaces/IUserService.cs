using Domain.Enitity;
using Domain.Response;

namespace Service.Interfaces
{
    public interface IUserService
    {
        Task<IBaseResponse<List<User>>> GetUsers();
        Task<IBaseResponse<bool>> Create(UserViewModel user);
        Task<IBaseResponse<bool>> DeleteById(int id);
        Task<IBaseResponse<bool>> UpdateById(int id, UserViewModel user);
        Task<IBaseResponse<User>> GetById(int id);

    }
}
