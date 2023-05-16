using Microsoft.AspNetCore.Mvc;

namespace TaskTracker.Areas.Admin.Controllers {

    [Area("Admin")]
    public class TaskController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
