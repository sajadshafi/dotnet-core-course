using DI_Autofac.IServices;
using DI_Autofac.Models;

namespace DI_Autofac.Services
{
  public class StudentService : IStudentService
  {
    public int DeleteStudent(int id)
    {
      Console.WriteLine("Student Deleted Successfully!\n");
      return 0;
    }

    public List<Student> GetAllStudents()
    {
      Console.WriteLine("All Students are!\n");
      return new List<Student>();
    }

    public Student GetStudentById(int id)
    {
        Console.WriteLine("Student found!\n");
      return null;
    }

    public Student SaveStudent(Student model)
    {
      Console.WriteLine("Student Saved Successfully!\n");
      return null;
    }
  }

}