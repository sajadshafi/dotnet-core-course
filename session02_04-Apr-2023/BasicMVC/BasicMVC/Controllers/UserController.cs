using BasicMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasicMVC.Controllers {
    public class UserController : Controller {
        private ILogger<UserController> _logger { get; set; }
        public UserController(ILogger<UserController> logger) {
            _logger = logger;
        }
        public IActionResult Index() {
            _logger.LogInformation("This is User Controller");
            User user = new User {
                Id= 1,
                Name="Faisal"
            };
            return View(user);
        }
    }
}
