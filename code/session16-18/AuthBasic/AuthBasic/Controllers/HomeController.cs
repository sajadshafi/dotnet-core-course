using AuthBasic.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AuthBasic.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContext;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContext) {
            _logger = logger;
            this._httpContext = httpContext;
        }

        public IActionResult Index() {
            _logger.LogError("User is: {0}", _httpContext.HttpContext.Session.GetString("User"));

            bool userExist = _httpContext.HttpContext.Session.GetString("User") != null;
            _logger.LogError("User exist: {0}", userExist.ToString());
            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        public IActionResult Dashboard() {
            return Ok("This is dashboard");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}