using CollegeProject.Models;
using CollegeProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CollegeProject.Controllers
{
    public class StudentController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly ApplicationDbContext _db;

        public StudentController(IConfiguration config, IWebHostEnvironment hostEnvironment)
        {
            _config = config;
            _hostEnvironment = hostEnvironment;
            _db = new(_config);
        }

        public async Task<IActionResult> Index()
        {
            List<Student> students = await _db.Students.ToListAsync();

            List<StudentModel> studentsVM = new();
            foreach (var student in students)
            {
                StudentModel st = new StudentModel
                {
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
        public async Task<IActionResult> AddStudent()
        {
            ViewBag.Courses = await _db.Courses.ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromForm] StudentModel model)
        {
            if (ModelState.IsValid)
            {

                Student newStudent = new Student()
                {
                    Name = model.Name,
                    Phone = model.Phone,
                    Email = model.Email,
                    CourseId = model.CourseId
                };

                //MyPhoto_98766876876867.jpg
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string imageName = Path.GetFileNameWithoutExtension(model.Image.FileName);
                string imageExtension = Path.GetExtension(model.Image.FileName);

                List<string> acceptedFiles = new List<string>(){
          ".jpg",
          ".png",
          ".webp",
          ".jpeg"
        };

                if (model.Image.Length > 200000)
                {
                    TempData["result"] = "Image is large, image must be less than 200KB";
                    ViewBag.Courses = await _db.Courses.ToListAsync();
                    return View();
                }

                if (acceptedFiles.Contains(imageExtension))
                {
                    string imagePath = imageName + DateTime.Now.ToString("yymmssfff") + imageExtension;

                    bool exists = System.IO.Directory.Exists(wwwRootPath + "/Images/");
                    if (!exists) System.IO.Directory.CreateDirectory(wwwRootPath + "/Images/");

                    string path = Path.Combine(wwwRootPath + "/Images/", imagePath);
                    try
                    {
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await model.Image.CopyToAsync(fileStream);
                        }
                        newStudent.ImagePath = imagePath;

                        await _db.Students.AddAsync(newStudent);
                        await _db.SaveChangesAsync();
                        TempData["result"] = "Saved Successfully!" + model.Image.Length;
                        return RedirectToAction(nameof(Index));
                    }
                    catch (Exception ex)
                    {
                        TempData["result"] = "Exception occured" + ex.Message;
                        return View();
                    }
                }
                else
                {
                    TempData["result"] = "Image not supported";
                    ViewBag.Courses = await _db.Courses.ToListAsync();
                    return View();
                }
            }
            else
            {
                TempData["result"] = "Model is not valid";
                ViewBag.Courses = await _db.Courses.ToListAsync();
                return View();
            }
        }

        public async Task<IActionResult> StudentDetails(int? Id)
        {

            if (Id == null)
            {
                TempData["result"] = "Id not valid";
                return RedirectToAction(nameof(Index));
            }

            StudentModel student = await _db.Students
            .Select(x => new StudentModel()
            {
                Id = x.Id,
                Name = x.Name,
                CourseId = x.CourseId,
                Phone = x.Phone,
                Email = x.Email,
                ImagePath = x.ImagePath
            }).FirstOrDefaultAsync(st => st.Id == Id);

            if (student == null)
            {
                TempData["result"] = "Student not found";
                return RedirectToAction(nameof(Index));
            }

            return View(student);
        }

        public async Task<IActionResult> UpdateProfile(int id)
        {
            // Request.Form.Files
            Student student = await _db.Students.FirstOrDefaultAsync(x => x.Id == id);
            try
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                bool fileExist = System.IO.File.Exists(wwwRootPath + "/Images/" + student.ImagePath);
                if (fileExist)
                {
                    string d_path = Path.Combine(wwwRootPath + "/Images/", student.ImagePath);
                    System.IO.File.Delete(d_path);
                }

                bool exists = System.IO.Directory.Exists(wwwRootPath + "/Images/");
                if (!exists) System.IO.Directory.CreateDirectory(wwwRootPath + "/Images/");

                if (Request.Form.Files.Count > 0)
                {
                    string imageName = Path.GetFileNameWithoutExtension(Request.Form.Files[0].FileName);
                    string imageExtension = Path.GetExtension(Request.Form.Files[0].FileName);

                    string imagePath = imageName + DateTime.Now.ToString("yymmssfff") + imageExtension;

                    string path = Path.Combine(wwwRootPath + "/Images/", imagePath);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await Request.Form.Files[0].CopyToAsync(fileStream);
                    }
                    student.ImagePath = imagePath;
                    TempData["result"] = "Image updated successfully!";
                }
                else student.ImagePath = null;
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                TempData["result"] = "Failed to delete File " + ex.Message;
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteImage(int id, string image)
        {
            Student st = await _db.Students.FirstOrDefaultAsync(s => s.Id == id);
            try
            {
                bool fileExist = System.IO.File.Exists(_hostEnvironment.WebRootPath + "/Images/" + image);
                if (!fileExist)
                {
                    TempData["result"] = "File deleted successfully!";
                }
                else
                {
                    string path = Path.Combine(_hostEnvironment.WebRootPath + "/Images/", image);
                    System.IO.File.Delete(path);
                }
                st.ImagePath = null;
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                TempData["result"] = "Failed to delete File " + ex.Message;
                return View();
            }
        }
        #region Edit Course
        [HttpGet]
        public async Task<IActionResult> EditStudent(int Id)
        {
            ApplicationDbContext db = new(_config);
            Student sstu = await db.Students.FirstOrDefaultAsync(s => s.Id == Id);
            if (sstu != null)
            {
                StudentModel sm = new StudentModel
                {
                    Id = sstu.Id,
                    Name = sstu.Name,
                    Email=sstu.Email,
                    ImagePath = sstu.ImagePath,
                    Phone= sstu.Phone,
                    CourseId= sstu.CourseId
                };
                return View(sm);
            }
            else
            {
                TempData["result"] = "Student not found";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditStudent([FromForm] StudentModel student)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Student updateableStudent = await _db.Students.FirstOrDefaultAsync(x => x.Id == student.Id);
                    updateableStudent.Name = student.Name;
                    updateableStudent.Phone = student.Phone;
                    updateableStudent.Email = student.Email;
                    updateableStudent.ImagePath = student.ImagePath;
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string imageName = Path.GetFileNameWithoutExtension(student.Image.FileName);
                    string imageExtension = Path.GetExtension(student.Image.FileName);
                    List<string> acceptedFiles = new List<string>(){
                     ".jpg",
                     ".png",
                     ".webp",
                     ".jpeg"
                    };
                    if (student.Image.Length > 200000)
                    {
                        TempData["result"] = "Image is large, image must be less than 200KB";
                        ViewBag.Courses = await _db.Courses.ToListAsync();
                        return View();
                    }
                    if (acceptedFiles.Contains(imageExtension))
                    {
                        string imagePath = imageName + DateTime.Now.ToString("yymmssfff") + imageExtension;

                        bool exists = System.IO.Directory.Exists(wwwRootPath + "/Images/");
                        if (!exists) System.IO.Directory.CreateDirectory(wwwRootPath + "/Images/");

                        string path = Path.Combine(wwwRootPath + "/Images/", imagePath);
                        try
                        {
                            using (var fileStream = new FileStream(path, FileMode.Create))
                            {
                                await student.Image.CopyToAsync(fileStream);
                            }
                            updateableStudent.ImagePath = imagePath;

                            //await _db.Students.AddAsync(updateableStudent);
                            await _db.SaveChangesAsync();
                            TempData["result"] = "Updated Successfully!" + student.Image.Length;
                            return RedirectToAction(nameof(Index));
                        }
                        catch (Exception ex)
                        {
                            TempData["result"] = "Exception occured" + ex.Message;
                            return View();
                        }
                    }
                    else
                    {
                        TempData["result"] = "Image not supported";
                        ViewBag.Courses = await _db.Courses.ToListAsync();
                        return View();
                    }

                   
                }
                catch (Exception ex)
                {
                    TempData["result"] = "Exception occured " + ex.Message;
                    return RedirectToAction("Index");
                }
            }
            else
            {
                TempData["result"] = "Not found";
                return RedirectToAction("Index");
            }
        }
        #endregion

        #region Delete Student
        [HttpGet]
        public async Task<IActionResult> DeleteStudent(int? Id)
        {
            if (Id == null)
            {
                TempData["result"] = "Id not valid";
                return RedirectToAction("Index");
            }
            else
            {
                Student st = await _db.Students.FirstOrDefaultAsync(x => x.Id == Id);
                if (st != null)
                {
                    try
                    {
                        _db.Students.Remove(st);
                        await _db.SaveChangesAsync();
                        TempData["result"] = "Student deleted Successfully";

                    }
                    catch (Exception ex)
                    {

                        TempData["result"] = "Exception occured" + ex.Message;
                    }
                }
                else
                {
                    TempData["result"] = "Student not found";
                }
            }
            return RedirectToAction("Index");
        }
        #endregion
    }
}