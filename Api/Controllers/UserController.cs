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
        public async Task<IActionResult> GetUsersAsync()
        {
            var response = await _userService.GetUsersAsync();
            return Ok(response);
        }

        [Authorize(Roles = "MainAdmin,MainRegistryWorker")]
        [HttpDelete]
        public async Task<IActionResult> DeleteByIdAsync(int id)
        {
            var response = await _userService.DeleteByIdAsync(id);
            if (response)
                return Ok(response);
            return BadRequest(response);
        }

        [Authorize(Roles = "MainAdmin, MainRegistryWorker")]
        [HttpPost]
        public async Task<IActionResult> UpdateByIdAsync(int id, UserViewModel model)
        {
            var response = await _userService.UpdateByIdAsync(id, model);
            if (response)
                return Ok(response);
            return BadRequest(response);
        }
    }
}
