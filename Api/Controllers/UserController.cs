using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Domain.Enitity;
using Service.Interfaces;
using Domain.Enum;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        public async Task<IActionResult> GetUsers()
        {
            var response = await _userService.GetUsers();

            return View(response.Data);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> DeleteById(int id)
        {
           
            var response = await _userService.DeleteById(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("GetUsers");
            }
            return RedirectToAction("Error");
        }

        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> UpdateById(int id,string login, string password)
        {
           var response = await _userService.UpdateById(id,new UserViewModel { Login = login, Password = password });
            if(response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("GetUsers");

            }
            return RedirectToAction("Error");

        }

       
    }
}
