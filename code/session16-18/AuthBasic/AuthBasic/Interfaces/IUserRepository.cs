using AuthBasic.Models.ViewModels;
using AuthBasic.Utils;

namespace AuthBasic.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> Login(LoginVM model);
        Task<bool> Register(UserVM model);
    }
}
