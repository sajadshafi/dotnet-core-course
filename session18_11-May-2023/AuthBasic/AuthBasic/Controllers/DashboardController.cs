using AuthBasic.Utils.CustomAttributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthBasic.Controllers {
    public class DashboardController : Controller {
        private readonly IHttpContextAccessor _httpContext;

        public DashboardController(IHttpContextAccessor httpContext) {
            this._httpContext = httpContext;
        }

        
        public IActionResult Index() {
            string UserId = _httpContext.HttpContext.Session.GetString("UserId");

            if(UserId == null) {
                TempData["error"] = "User is not authorized please login first";
                return RedirectToAction("Login", "User");
            }
            return View();
        }
    }
}
