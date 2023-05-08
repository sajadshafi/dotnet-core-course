using AuthBasic.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AuthBasic.Controllers {
    public class UserController : Controller {
        public UserController() {

        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Login(LoginVM model) => Ok("Login Successful");

        [HttpPost]
        public IActionResult Register(UserVM model) => Ok("Registered Successful");
    }
}
