using DAL.Interfaces;
using Domain.Enitity;
using Domain.Enitity.AccountViewsModel;
using Domain.Enum;
using Domain.Helpers;
using Domain.Response;
using Microsoft.EntityFrameworkCore;
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

            if (user.Password != HashPasswordHelper.HashPassword(model.Password))
            {
                return new ClaimsIdentity();
            }
            var result = Authenticate(user);
            return result;
        }

        public async Task<bool> Register(RegisterViewModel model)
        {
            var user = await _userRepository.GetByLogin(model.Login);
            if (user == null)
            {
                user = new User()
                {
                    Login = model.Login,
                    Role = model.UserRole,
                    Password = HashPasswordHelper.HashPassword(model.Password),
                };
                await _userRepository.Create(user);
            }
            else
            {
                return false;
            }
            return true;
        }

        private ClaimsIdentity Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
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
