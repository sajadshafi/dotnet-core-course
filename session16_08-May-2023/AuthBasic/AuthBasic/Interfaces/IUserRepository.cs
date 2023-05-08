using AuthBasic.Models.ViewModels;
using AuthBasic.Utils;

namespace AuthBasic.Interfaces {
    public interface IUserRepository {
        Task<Response<LoginResponse>> Login(LoginVM model);
        Task<Response<LoginResponse>> Register(UserVM model);
    }
}
