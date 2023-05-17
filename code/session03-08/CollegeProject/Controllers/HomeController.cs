using CollegeProject.Models;
using CollegeProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CollegeProject.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;

        public HomeController(ILogger<HomeController> logger, IConfiguration config) {
            _logger = logger;
            _config = config;
        }

        public IActionResult Index() {
            ApplicationDbContext context = new ApplicationDbContext(_config);
            var students = context.Students.Include(x => x.Course).ToList();
            if(students.Count > 0) {
                List<StudentModel> studentsmodel = new();
                foreach(var student in students) {
                    StudentModel stdMd = new StudentModel();
                    StudentModel.MapStudent(student, stdMd);
                    studentsmodel.Add(stdMd);
                }
                return View(studentsmodel);
            }
            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}