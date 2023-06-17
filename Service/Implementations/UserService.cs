using DAL.Interfaces;
using Domain.Enitity;
using Domain.Enum;
using Domain.Response;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IBaseResponse<bool>> Create(UserViewModel user)
        {
            var baseResponse = new BaseResponse<bool>();
            try
            {
                var User = new User()
                {
                    Login = user.Login,
                    Password = user.Password, 
                };
                await _userRepository.Create(User);
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[GetUsers] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError,
                };

            }
            return baseResponse;    
           
        }

        public async Task<IBaseResponse<IEnumerable<User>>> GetUsers()
        {
            var baseResponse = new BaseResponse<IEnumerable<User>>();
            try
            {
                var users = await _userRepository.Select();
                if(users.Count == 0)
                {
                    baseResponse.Description = "Найдено 0 пользователей";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }

                baseResponse.Data = users;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;

            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<User>>()
                {
                    Description = $"[GetUsers] : {ex.Message}"
                };
            }
        }

        public async Task<IBaseResponse<bool>> DeleteById(int id)
        {
            var baseResponse = new BaseResponse<bool>();
            try
            {
                if (await _userRepository.DeleteById(id))
                {
                    baseResponse.Data = true;
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                else 
                { return new BaseResponse<bool>() { Description = $"[DeleteById] : {StatusCode.UserNotFound}" }; }
            }
            catch (Exception ex)
            {

                return new BaseResponse<bool>()
                {
                    Description = $"[DeleteById] : {ex.Message}"
                };
            }

        }

        public async Task<IBaseResponse<bool>> UpdateById(int id, UserViewModel user)
        {
            var baseResponse = new BaseResponse<bool>();
            try
            {
                var model = await _userRepository.GetById(id);
                if(model  == null)
                {
                    baseResponse.Data = false;
                    baseResponse.StatusCode = StatusCode.UserNotFound;
                    return baseResponse;
                }
                model.Login = user.Login;
                model.Password = user.Password;
                if (await _userRepository.Update(model))
                {
                    baseResponse.StatusCode= StatusCode.OK;
                    baseResponse.Data = true;
                    return baseResponse;
                }
                else
                {
                    baseResponse.Data = false;
                    baseResponse.StatusCode = StatusCode.InternalServerError;
                    return baseResponse;
                }
            }
            catch (Exception ex)
            {

                return new BaseResponse<bool>()
                {
                    Description = $"[UpdateById] : {ex.Message}"
                };
            }
        }
    }
}
   
