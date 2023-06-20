using Domain.Enitity.AccountViewsModel;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Domain.Enum;

namespace Api.Controllers
{
    public class AccountController : Controller
    {

        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        
        [HttpGet]
        [Authorize(Roles = "MainRegistryWorker,MainAdmin")]
            
        public IActionResult Registration() => View();

        [HttpPost]
        [Authorize(Roles = "MainRegistryWorker,MainAdmin")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _accountService.Register(model);
                if (response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", response.Description);
            }
            return View("Registration");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login() => View();

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _accountService.Login(model);
                if (response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(response.Data));

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", response.Description);
            }
            return View("Login");
        }

        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }

    public class PatientsController : Controller
    {
        [HttpGet]
        [Authorize(Roles = "MainRegistryWorker, MainAdmin")]
        public IActionResult Index()
        {
            return View("~/Views/Home/Patients.cshtml");
         
        }
    }

    public class DoctorsController : Controller
    {
        [HttpGet]
        [Authorize(Roles = "MainRegistryWorker, MainAdmin")]
        public IActionResult Index()
        {
            // Логика обработки страницы Doctors
            return View("~/Views/Home/Doctors.cshtml");
        }
    }

    public class TicketController : Controller
    {
        [HttpGet]
        [Authorize(Roles = "MainRegistryWorker, MainAdmin")]
        public IActionResult Index()
        {
            // Логика обработки страницы Ticket
            return View("~/Views/Home/Ticket.cshtml");
        }
    }




}
