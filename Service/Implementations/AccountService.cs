using DAL.Interfaces;
using Domain.Enitity;
using Domain.Enitity.AccountViewsModel;
using Domain.Helpers;
using Service.Interfaces;
using System.Security.Claims;

namespace Service.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;

        public AccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ClaimsIdentity> LoginAsync(LoginViewModel model)
        {
            var user = await _userRepository.GetByLogin(model.Login);

            if (user.password != HashPasswordHelper.HashPassword(model.Password))
            {
                return new ClaimsIdentity();
            }
            var result = Authenticate(user);
            return result;
        }

        public async Task<bool> RegisterAsync(RegisterViewModel model)
        {
            var user = await _userRepository.GetByLogin(model.Login);
            if (model.UserRole != 0)
            {
                if (user == null)
                {
                    user = new User()
                    {
                        username = model.Login,
                        role = model.UserRole,
                        password = HashPasswordHelper.HashPassword(model.Password),
                    };
                    await _userRepository.Create(user);
                }
                else
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        private ClaimsIdentity Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.username),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.role.ToString())
            };
            return new ClaimsIdentity(
                claims,
                "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType
            );
        }
    }
}
