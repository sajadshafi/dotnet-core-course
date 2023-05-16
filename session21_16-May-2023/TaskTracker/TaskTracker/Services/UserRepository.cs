using Microsoft.AspNetCore.Identity;
using TaskTracker.IServices;
using TaskTracker.Models;
using TaskTracker.Models.ViewModels;

namespace TaskTracker.Services {
    public class UserRepository : IUserRepository {
        private readonly UserManager<SystemUser> _userManager;
        private readonly SignInManager<SystemUser> _signInManager;
        private readonly RoleManager<SystemRole> _roleManager;

        public UserRepository(UserManager<SystemUser> userManager, SignInManager<SystemUser> signInManager, RoleManager<SystemRole> roleManager) {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._roleManager = roleManager;
        }

        public async Task<bool> CreateRoleAsync(string roleName) {
            if (roleName == null) return false;
            IdentityResult result = await _roleManager.CreateAsync(new SystemRole() { Name = roleName });

            return result.Succeeded;
        }

        public async Task<bool> LoginAsync(LoginVM model) {
            SystemUser user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null) {
                return false;
            }

            SignInResult result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            return result.Succeeded;
        }

        public async Task LogoutAsync() {
            await _signInManager.SignOutAsync();
        }

        public async Task<bool> RegisterAsync(UserVM model) {

            SystemUser newUser = new() {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
            };

            IdentityResult result = await _userManager.CreateAsync(newUser, model.Password);

            return result.Succeeded;
        }
    }
}
