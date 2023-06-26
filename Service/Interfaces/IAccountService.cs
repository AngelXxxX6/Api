using Domain.Enitity.AccountViewsModel;
using Domain.Response;
using System.Security.Claims;

namespace Service.Interfaces
{
    public interface IAccountService
    {

        Task<BaseResponse<bool>> Register(RegisterViewModel model);
        Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model);


    }
}
