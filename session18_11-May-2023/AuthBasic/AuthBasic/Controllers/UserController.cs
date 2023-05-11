using AuthBasic.Interfaces;
using AuthBasic.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthBasic.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _repository;
        private readonly IHttpContextAccessor _httpContext;

        public UserController(IUserRepository repository, IHttpContextAccessor _httpContext)
        {
            _repository = repository;
            this._httpContext = _httpContext;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            bool result = await _repository.Login(model);
            if (result)
            {
                TempData["result"] = "Login successful!";
                return RedirectToAction("Index", "Home");
            }
            TempData["error"] = "Login failed!";
            return View();
        }

        //=> Ok("Login Successful");

        [HttpPost]
        public async Task<IActionResult> Register(UserVM model)
        {
            if (!ModelState.IsValid) return View();

            bool result = await _repository.Register(model);
            if (result)
            {
                TempData["result"] = "Register successful!";
                return RedirectToAction(nameof(Login));
            }
            TempData["error"] = "Register failed!";
            return View();
        }
        public IActionResult LogOut() {
            _httpContext.HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
