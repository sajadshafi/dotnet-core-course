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
          CourseId = student.CourseId,
          ImagePath = student.ImagePath
        };
        studentsVM.Add(st);
      }

      return View(studentsVM);
    }

    [HttpGet]
    public async Task<IActionResult> AddStudent() {
      ViewBag.Courses = await _db.Courses.ToListAsync();
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddStudent([FromForm]StudentModel model) {
      if(ModelState.IsValid) {

        Student newStudent = new Student() {
          Name = model.Name,
          Phone = model.Phone,
          Email = model.Email,
          CourseId = model.CourseId
        };

        //MyPhoto_98766876876867.jpg
        string wwwRootPath = _hostEnvironment.WebRootPath;
        string imageName = Path.GetFileNameWithoutExtension(model.Image.FileName);
        string imageExtension = Path.GetExtension(model.Image.FileName);

        string imagePath = imageName + DateTime.Now.ToString("yymmssfff") + imageExtension;

        bool exists = System.IO.Directory.Exists(wwwRootPath + "/Images/");
        if(!exists) System.IO.Directory.CreateDirectory(wwwRootPath + "/Images/");

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
         ViewBag.Courses = await _db.Courses.ToListAsync();
        return View();
      }
    }
  
    public async Task<IActionResult> StudentDetails(int? Id) {

      if(Id == null) {
        TempData["result"] = "Id not valid";
        return RedirectToAction(nameof(Index));
      }

      StudentModel student = await _db.Students
      .Select(x => new StudentModel() {
        Id = x.Id,
        Name = x.Name,
        CourseId = x.CourseId,
        Phone = x.Phone,
        Email = x.Email,
        ImagePath = x.ImagePath
      }).FirstOrDefaultAsync(st => st.Id == Id);
      
      if(student == null) {
        TempData["result"] = "Student not found";
        return RedirectToAction(nameof(Index));
      }

      return View(student);
    }
  
    public IActionResult UpdateProfile(StudentModel model) {
      // Request.Form.Files
      return Ok("Image updated successfully");
    }

    [HttpGet]
    public async Task<IActionResult> DeleteImage(int id, string image) {
      Student st = await _db.Students.FirstOrDefaultAsync(s => s.Id == id);
      try {
        bool fileExist = System.IO.File.Exists(_hostEnvironment.WebRootPath + "/Images/" + image);
        if(!fileExist) {
          TempData["result"] = "File deleted successfully!";
        }
        else {
          string path = Path.Combine(_hostEnvironment.WebRootPath + "/Images/", image);
          System.IO.File.Delete(path);
        }
        st.ImagePath = null;
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));

      } catch(Exception ex) {
        TempData["result"] = "Failed to delete File "+ ex.Message;
        return View();
      }
    }
  }
}