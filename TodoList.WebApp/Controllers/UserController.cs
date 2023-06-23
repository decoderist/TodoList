using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoList.WebApp.Models.UserViewModel;
using IAuthenticationService = TodoList.WebApp.Contracts.IAuthenticationService;

namespace TodoList.WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IAuthenticationService _authService;

        public UserController(IAuthenticationService authService)
        {
            this._authService = authService;
        }

        public IActionResult Login(string returnUrl = null)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM login, string returnUrl)
        {
            returnUrl ??= Url.Content("~/");
            var isLoggedIn = await _authService.Authenticate(login.Email, login.Password);
            if (isLoggedIn)
                return LocalRedirect(returnUrl);
            ModelState.AddModelError("", "Log In Attempt Failed. Please try again.");
            return View(login);
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registration)
        {
            if (ModelState.IsValid)
            {
                var returnUrl = Url.Content("~/");
                var isCreated = await _authService.Register(registration);
                if (isCreated)
                    return LocalRedirect(returnUrl);
            }
            ModelState.AddModelError("", "Registration Attempt Failed. Please try again.");
            return View(registration);
        }

        [HttpPost]
        public async Task<IActionResult> Logout(string returnUrl)
        {
            returnUrl ??= Url.Content("~/");
            await _authService.Logout();
            return LocalRedirect(returnUrl);
        }

    }
}
