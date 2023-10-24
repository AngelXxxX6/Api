using Domain.Enitity.AccountViewsModel;

using System.Security.Claims;

namespace Service.Interfaces
{
    public interface IAccountService
    {
        Task<bool> RegisterAsync(RegisterViewModel model);
        Task<ClaimsIdentity> LoginAsync(LoginViewModel model);
    }
}
