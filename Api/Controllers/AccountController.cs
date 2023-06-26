using Domain.Enitity.AccountViewsModel;
using Domain.Enum;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Security.Claims;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }


        [HttpPut]
        [Authorize(Roles = "MainRegistryWorker,MainAdmin")]

        public async Task<StatusCode> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _accountService.Register(model);

                return response.StatusCode;
            }
            else return Domain.Enum.StatusCode.ModelInvail;

        }



        [HttpPost]
        [AllowAnonymous]

        public async Task<StatusCode> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _accountService.Login(model);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(response.Data));

                return response.StatusCode;

            }
            return Domain.Enum.StatusCode.ModelInvail;
        }


        [Authorize]
        [HttpGet]
        [Route("/[controller]/LogOut")]
        public async Task<StatusCode> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Domain.Enum.StatusCode.OK;
        }
    }
}
