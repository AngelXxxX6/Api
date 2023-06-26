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
        public async Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model)
        {
            try
            {
                var user = await _userRepository.Select().FirstOrDefaultAsync(x => x.Login == model.Login);
                if (user == null)
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "UserNoFound"
                    };
                }

                if (user.Password != HashPasswordHelper.HashPassword(model.Password))
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "Incorrect user or password"
                    };
                }
                var result = Authenticate(user);

                return new BaseResponse<ClaimsIdentity>()
                {
                    Data = result,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {

                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = $"[Login : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<BaseResponse<bool>> Register(RegisterViewModel model)
        {

            try
            {
                var user = await _userRepository.Select().FirstOrDefaultAsync(x => x.Login == model.Login);
                if (user != null)
                {
                    return new BaseResponse<bool>()
                    {
                        Description = "User with this name already exists ",
                    };
                }

                user = new User()
                {
                    Login = model.Login,
                    Role = model.UserRole,
                    Password = HashPasswordHelper.HashPassword(model.Password),
                };

                await _userRepository.Create(user);



                return new BaseResponse<bool>()
                {
                    Data = true,
                    Description = "User added",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {

                return new BaseResponse<bool>()
                {
                    Description = $"[Register] :{ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }

        }
        private ClaimsIdentity Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
            };
            return new ClaimsIdentity(claims, "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }
    }
}
