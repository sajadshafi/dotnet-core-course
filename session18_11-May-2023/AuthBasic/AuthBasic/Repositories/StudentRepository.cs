using AuthBasic.Models.ViewModels;
using AuthBasic.Models;
using Microsoft.EntityFrameworkCore;
using AuthBasic.Interfaces;

namespace AuthBasic.Repositories
{
    public class StudentRepository:IStudentRepository
    {
        private readonly TodoContext _context;
        private readonly ILogger<UserRepository> _logger;
        private readonly IHttpContextAccessor _httpContext;

        public StudentRepository(TodoContext context, ILogger<UserRepository> logger, IHttpContextAccessor httpContext)
        {
            this._context = context;
            this._logger = logger;
            this._httpContext = httpContext;
        }
        public async Task<bool> AddStudent(StudentVM model)
        {
            Student newStudent = new();
            StudentVM.MapUserVMToEntity(model, newStudent);

            try
            {
                await _context.Students.AddAsync(newStudent);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());

                return false;
            }
        }
    }
}
