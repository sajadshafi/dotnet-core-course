using AuthBasic.Models.ViewModels;

namespace AuthBasic.Interfaces
{
    public interface IStudentRepository
    {
        Task<bool> AddStudent(StudentVM model);
    }
}
