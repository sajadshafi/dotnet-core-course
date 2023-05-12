using AuthBasic.Interfaces;
using AuthBasic.Models;
using AuthBasic.Models.ViewModels;
using AuthBasic.Utils.CustomAttributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthBasic.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly TodoContext _context;
        //private object _repository;
        private readonly IStudentRepository _repository;

        public DashboardController(IStudentRepository repository ,IHttpContextAccessor httpContext, TodoContext context)
        {
            this._httpContext = httpContext;
            this._context = context;
            this._repository = repository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            string UserId = _httpContext.HttpContext.Session.GetString("UserId");
            if (UserId == null)
            {
                TempData["error"] = "User is not authorized please login first";
                return RedirectToAction("Login", "User");
            }
            IEnumerable<User> users = _context.Users;
            if (users == null)
            {
                users = new List<User>();
            }
            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(StudentVM model)
        {
            if (!ModelState.IsValid) return View();

            bool result = await _repository.AddStudent(model);
            if (result)
            {
                TempData["result"] = "Student Added successful!";
                return RedirectToAction("Index", "Dashboard");
            }
            TempData["error"] = "Something went wrong!";
            return View();
        }

    }
}
