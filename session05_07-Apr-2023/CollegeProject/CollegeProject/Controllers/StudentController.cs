using CollegeProject.Models;
using CollegeProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CollegeProject.Controllers {
  public class StudentController : Controller {
    private readonly IConfiguration _config;
    private readonly IWebHostEnvironment _hostEnvironment;
    private readonly ApplicationDbContext _db;

    public StudentController(IConfiguration config, IWebHostEnvironment hostEnvironment) {
      _config = config;
      _hostEnvironment = hostEnvironment;
      _db = new(_config);
    }
    
    public async Task<IActionResult> Index() {
      List<Student> students = await _db.Students.ToListAsync();

      List<StudentModel> studentsVM = new();
      foreach(var student in students) {
        StudentModel st = new StudentModel {
          Id = student.Id,
          Name = student.Name,
          Phone = student.Phone,
          Email = student.Email,
          CourseId = student.CourseId
        };
        studentsVM.Add(st);
      }

      return View(studentsVM);
    }

    [HttpGet]
    public IActionResult AddStudent() {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddStudent([FromForm]StudentModel model) {
      if(ModelState.IsValid) {

        Student newStudent = new Student() {
          Name = model.Name,
          Phone = model.Phone,
          Email = model.Email,
        };

        //MyPhoto_98766876876867.jpg
        string wwwRootPath = _hostEnvironment.WebRootPath;
        string imageName = Path.GetFileNameWithoutExtension(model.Image.FileName);
        string imageExtension = Path.GetExtension(model.Image.FileName);

        string imagePath = imageName + DateTime.Now.ToString("yymmssfff") + imageExtension;

        string path = Path.Combine(wwwRootPath + "/Images/", imagePath);
        try {
          using (var fileStream = new FileStream(path, FileMode.Create))
          {
              await model.Image.CopyToAsync(fileStream);
          }
          newStudent.ImagePath = imagePath;

          await _db.Students.AddAsync(newStudent);
          await _db.SaveChangesAsync();
          TempData["result"] = "Saved Successfully!";
          return RedirectToAction(nameof(Index));
        } catch(Exception ex) {
          TempData["result"] = "Exception occured" + ex.Message;
          return View();
        }
      } else {
        TempData["result"] = "Model is not valid";
        return View();
      }
    }
  }
}