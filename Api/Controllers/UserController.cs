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
        public async Task<IActionResult> GetUsers()
        {
            var response = await _userService.GetUsers();
            return Ok(response);
        }

        [Authorize(Roles = "MainAdmin,MainRegistryWorker")]
        [HttpDelete]
        public async Task<IActionResult> DeleteById(int id)
        {
            var response = await _userService.DeleteById(id);
            if (response)
                return Ok(response);
            return BadRequest(response);
        }

        [Authorize(Roles = "MainAdmin, MainRegistryWorker")]
        [HttpPost]
        public async Task<IActionResult> UpdateById(int id, UserViewModel model)
        {
            var response = await _userService.UpdateById(id, model);
            if (response)
                return Ok(response);
            return BadRequest(response);
        }
    }
}
