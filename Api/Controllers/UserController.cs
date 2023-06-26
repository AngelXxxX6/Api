using Domain.Enitity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize(Roles = "MainAdmin,MainRegistryWorker")]
        [HttpGet]

        public async Task<IEnumerable<User>> GetUsers()
        {
            var response = await _userService.GetUsers();

            return response.Data;
        }

        [Authorize(Roles = "MainAdmin,MainRegistryWorker")]
        [HttpDelete]

        public async Task<bool> DeleteById(int id)
        {

            var response = await _userService.DeleteById(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return true;
            }
            return false; ;
        }

        [Authorize(Roles = "MainAdmin, MainRegistryWorker")]
        [HttpPost]
        public async Task<bool> UpdateById(int id, UserViewModel model)
        {
            var response = await _userService.UpdateById(id, model);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return true;

            }
            return false;

        }

    }
}
