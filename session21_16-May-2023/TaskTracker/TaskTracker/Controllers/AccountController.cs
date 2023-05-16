using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using TaskTracker.IServices;
using TaskTracker.Models.ViewModels;

namespace TaskTracker.Controllers {
    public class AccountController : Controller {
        private readonly IUserRepository _user;
        private readonly IToastNotification _notification;

        public AccountController(IUserRepository _user, IToastNotification notification) {
            this._user = _user;
            this._notification = notification;
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
                _notification.AddSuccessToastMessage("Login successful!");
                return RedirectToActionPermanent(nameof(Index), "Home");
            } else {
                _notification.AddSuccessToastMessage("Login Failed!");
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserVM model) {
            if (!ModelState.IsValid) return View();

            bool result = await _user.RegisterAsync(model);
            if (result) {
                _notification.AddSuccessToastMessage("Register successful!");
                return RedirectToActionPermanent(nameof(Index), "Home");
            } else {
                _notification.AddSuccessToastMessage("Register Failed!");
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Logout() {
            await _user.LogoutAsync();
            return RedirectToActionPermanent("Index", "Home");
        }

        [HttpGet]
        public IActionResult CreateRole() => View();

        [HttpPost]
        public async Task<IActionResult> CreateRole(string roleName) {
            bool result = await _user.CreateRoleAsync(roleName);
            if (result) {
                _notification.AddSuccessToastMessage("Register successful!");
                return RedirectToAction("Index", "Home");
            } else {
                _notification.AddSuccessToastMessage("Register Failed!");
                return View();
            }
        }
    }
}
