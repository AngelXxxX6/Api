﻿using Domain.Enitity.AccountViewsModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Security.Claims;

namespace Api.Controllers
{
    
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPut]
        [Authorize(Roles = "MainRegistryWorker,MainAdmin")]
        public async Task<IActionResult> RegisterAsync(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _accountService.RegisterAsync(model);
                return Ok(response);
            }
            else
                return BadRequest(ModelState);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _accountService.LoginAsync(model);
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(response)
                );
                return Ok(response.Name);
            }
            return BadRequest(ModelState);
        }

        [Authorize]
        [HttpGet]
        [Route("/[controller]/LogOut")]
        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }

        public IActionResult Home()
        {
            return View();
        } 
    }
}
