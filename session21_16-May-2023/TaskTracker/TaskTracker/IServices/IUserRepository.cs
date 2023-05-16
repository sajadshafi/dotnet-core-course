using TaskTracker.Models.ViewModels;

namespace TaskTracker.IServices {
    public interface IUserRepository {
        Task<bool> LoginAsync(LoginVM model);
        Task<bool> RegisterAsync(UserVM model);
        Task LogoutAsync();

        Task<bool> CreateRoleAsync(string role);
    }
}
