using AuthBasic.Interfaces;
using AuthBasic.Models;
using AuthBasic.Models.ViewModels;
using AuthBasic.Utils;

namespace AuthBasic.Repositories {
    public class UserRepository : IUserRepository {
        private readonly TodoContext _context;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(TodoContext context, ILogger<UserRepository> logger) {
            this._context = context;
            this._logger = logger;
        }
        public Task<Response<LoginResponse>> Login(LoginVM model) {
            throw new NotImplementedException();
        }

        public async Task<Response<LoginResponse>> Register(UserVM model) {
            User newUser = new();
            UserVM.MapUserVMToEntity(model, newUser);

            try {
                await _context.Users.AddAsync(newUser);
                await _context.SaveChangesAsync();

                return new Response<LoginResponse>() {
                    Count = 1,
                    Data = new LoginResponse() {
                        Id = newUser.Id,
                        Email = newUser.Email,
                        Name = newUser.Name,
                    },
                    Message = "User Registered successfully!",
                };
            } catch(Exception ex) {

                _logger.LogError(ex.ToString());

                return new Response<LoginResponse> {
                    Success = false,
                    Data = null,
                    Message = "An internal error occured",
                };
            }
            
        }
    }
}
