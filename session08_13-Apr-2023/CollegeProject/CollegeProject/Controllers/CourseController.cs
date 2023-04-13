using CollegeProject.Models;
using CollegeProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CollegeProject.Controllers
{
  public class CourseController : Controller {
    public readonly IConfiguration _config;
    public readonly ApplicationDbContext _db;
    public CourseController(IConfiguration config)
    {
      _config = config;
      _db = new(_config);
    }
    //Create / Delete / Update / Get
    public IActionResult Index() {
      ApplicationDbContext context = new ApplicationDbContext(_config);
            var courses = context.Courses.OrderByDescending(c => c.Id).ToList();
            if(courses.Count > 0) {
                List<CourseModel> coursesmodel = new();
                foreach(var c in courses) {
                    CourseModel stdMd = new();
                    stdMd.Id = c.Id;
                    stdMd.Name = c.Name;
                    stdMd.CourseFee = c.CourseFees;
                    coursesmodel.Add(stdMd);
                }
                return View(coursesmodel);
            }
      return View();
    }

    #region AddCourse
    [HttpGet]
    public IActionResult AddCourse() {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddCourse(CourseModel course) {
      if(ModelState.IsValid) {
        try {
          ApplicationDbContext context = new ApplicationDbContext(_config);
          Course newCourse = new Course{ Name = course.Name, CourseFees=course.CourseFee};
          await context.Courses.AddAsync(newCourse);
          await context.SaveChangesAsync();
          TempData["result"] = "Added successfully";
        } catch(Exception e) {
          Console.WriteLine("Error occured: ", e.Message);
          TempData["result"] = e.Message;
        }
      }
      else TempData["result"] = "Failed to add";
      Console.WriteLine("Course Name : {0}", course.Name);
      return RedirectToAction("Index");
    }
    #endregion
  
    #region Delete Course
    [HttpGet]
    public async Task<IActionResult> DeleteCourse(int? Id) {
      if(Id == null) {
        TempData["result"] = "Id not valid";
        return RedirectToAction("Index");
      }
      else {
        ApplicationDbContext context = new ApplicationDbContext(_config);
        Course c = await context.Courses.FirstOrDefaultAsync(x => x.Id == Id);
        if(c != null) {
          try {
            context.Courses.Remove(c);
            await context.SaveChangesAsync();
            TempData["result"] = "Course deleted Successfully";
          
          } catch(Exception ex) {

          TempData["result"] = "Exception occured" + ex.Message;
          }
        }
        else {
          TempData["result"] = "Course not found";
        }
      }
      return RedirectToAction("Index");
    }
    #endregion

    #region Edit Course
    [HttpGet]
    public async Task<IActionResult> EditCourse(int Id) {
      ApplicationDbContext db = new(_config);
      Course cCourse = await db.Courses.FirstOrDefaultAsync(c => c.Id == Id);
      if(cCourse != null) {
        CourseModel cm = new CourseModel{
          Id = cCourse.Id,
          Name = cCourse.Name,
          CourseFee = cCourse.CourseFees
        };
        return View(cm);
      } else {
        TempData["result"] = "Course not found";
        return RedirectToAction("Index");
      }
    }

    //PUT / DELETE / POST / GET

    [HttpPost]
    public async Task<IActionResult> EditCourse(CourseModel course) {
      if(ModelState.IsValid) {
        try {
          Course updateableCourse = await _db.Courses.FirstOrDefaultAsync(x => x.Id == course.Id);
          updateableCourse.CourseFees = course.CourseFee;
          updateableCourse.Name = course.Name;
          await _db.SaveChangesAsync();
          TempData["result"] = "Updated Successfully!";
          return RedirectToAction("Index");
          
        } catch(Exception ex) {
          TempData["result"] = "Exception occured " + ex.Message;
          return RedirectToAction("Index");
        }
      } else {
          TempData["result"] = "Not found";
          return RedirectToAction("Index");
      }
    }
    #endregion
  }
}