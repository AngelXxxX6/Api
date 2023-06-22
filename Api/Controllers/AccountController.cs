using Domain.Enitity.AccountViewsModel;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Implementations;
using Service.Interfaces;
using System.Security.Claims;

namespace Api.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        

        [HttpPost]
        [Authorize(Roles = "MainRegistryWorker,MainAdmin")]
        [Route("/Account/Register")]
        public async Task<bool> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _accountService.Register(model);
                if (response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    return true;
                }
                ModelState.AddModelError("", response.Description);
            }
            return false;
        }

        

        [HttpPost]
        [AllowAnonymous]
        [Route("/Account/Login")]
        public async Task<bool> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _accountService.Login(model);
                if (response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(response.Data));

                    return true;
                }
                ModelState.AddModelError("", response.Description);
            }
            return false;
        }

        [ValidateAntiForgeryToken]
        [Authorize]
        [Route("/Account/Logout")]
        [HttpGet]
        public async Task<bool> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return true;
        }
    }
}
