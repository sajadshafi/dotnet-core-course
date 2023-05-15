using Microsoft.AspNetCore.Mvc;
using TaskTracker.IServices;
using TaskTracker.Models.ViewModels;

namespace TaskTracker.Controllers {
    public class AccountController : Controller {
        private readonly IUserRepository _user;

        public AccountController(IUserRepository _user) {
            this._user = _user;
        }

        [HttpGet]
        public IActionResult Login() {
            return View();
        }

        [HttpGet]
        public IActionResult Register() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model) {
            if (!ModelState.IsValid) {
                return View();
            }

            bool result = await _user.LoginAsync(model);
            if (result) {
                TempData["result"] = "User Login Successfully!";
                return RedirectToActionPermanent(nameof(Index), "Home");
            } else {
                TempData["error"] = "User Login Failed!";
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserVM model) {
            if (!ModelState.IsValid) return View();

            bool result = await _user.RegisterAsync(model);
            if (result) {
                TempData["result"] = "User Registered Successfully!";
                return RedirectToActionPermanent(nameof(Index), "Home");
            } else {
                TempData["error"] = "User Registered Failed!";
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Logout() {
            await _user.LogoutAsync();
            return RedirectToActionPermanent("Index", "Home");
        }
    }
}
