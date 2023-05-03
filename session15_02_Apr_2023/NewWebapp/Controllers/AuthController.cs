using Microsoft.AspNetCore.Mvc;
using NewWebapp.IServices;

namespace NewWebapp.Controllers
{
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthenticationService _authService;

        public AuthController(ILogger<AuthController> logger, IAuthenticationService authService)
        {
            _logger = logger;
            _authService = authService;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return Ok(_authService.Register(new Models.User()));
        }

        public IActionResult UpdateUser()
        {
            return View();
        }

        public IActionResult ResetPassword()
        {
            return View();
        }
    }
}
