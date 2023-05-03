using DI_Autofac.Models;

namespace DI_Autofac.IServices
{
    public interface IStudentService
    {
        Student SaveStudent(Student model);
        int DeleteStudent(int id);
        List<Student> GetAllStudents();
        Student GetStudentById(int id);
    }
}