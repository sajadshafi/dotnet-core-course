using AuthBasic.Interfaces;
using AuthBasic.Models;
using AuthBasic.Models.ViewModels;
using AuthBasic.Utils;
using Microsoft.EntityFrameworkCore;

namespace AuthBasic.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TodoContext _context;
        private readonly ILogger<UserRepository> _logger;
        private readonly IHttpContextAccessor _httpContext;

        public UserRepository(TodoContext context, ILogger<UserRepository> logger, IHttpContextAccessor httpContext)
        {
            this._context = context;
            this._logger = logger;
            this._httpContext = httpContext;
        }

        public async Task<bool> Login(LoginVM model)
        {
            try
            {
                string password = Encrypt.EncryptPassword(model.Password);
                User user = await _context.Users.FirstOrDefaultAsync(
                    x => x.Email == model.Email && x.Password == password
                );

                if (user == null)
                {
                    return false;
                }
                else
                {
                    _httpContext.HttpContext.Session.SetString("UserId", user.Id.ToString());
                    _httpContext.HttpContext.Session.SetString("Email", user.Email);
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return false;
            }
        }

        public async Task<bool> Register(UserVM model)
        {
            User newUser = new();
            UserVM.MapUserVMToEntity(model, newUser);

            try
            {
                newUser.Password = Encrypt.EncryptPassword(newUser.Password);
                await _context.Users.AddAsync(newUser);
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
