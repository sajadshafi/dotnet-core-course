using BasicMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BasicMVC.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        public IActionResult Index() {
            ViewData["User"] = "Sajad Shafi";
            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        public IActionResult RegisterUser() {
            //lets register a user;
            TempData["SuccessMessage"] = "User Registered successfully";
            return RedirectToAction("Index", "User");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}