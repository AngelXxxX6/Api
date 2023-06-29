using DAL.Interfaces;
using Domain.Enitity;
using Service.Interfaces;
using System.Data;

namespace Service.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> CreateAsync(UserViewModel user)
        {
            if (user.Role != 0)
            {
                var User = new User()
                {
                    Login = user.Login,
                    Password = user.Password,
                    Role = user.Role,
                };
                await _userRepository.Create(User);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            var users = await _userRepository.Select();
            return users;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            if (id != 0)
            {
                var model = await _userRepository.GetById(id);
                await _userRepository.Delete(model);
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateByIdAsync(int id, UserViewModel user)
        {
            if (id != 0)
            {
                var model = await _userRepository.GetById(id);
                model.Login = user.Login;
                model.Password = user.Password;
                await _userRepository.Update(model);
                return true;
            }
            return false;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            User user = await _userRepository.GetById(id);
            return user;
        }
    }
}
