using NewWebapp.IServices;
using NewWebapp.Models;

namespace NewWebapp.Services
{
    public class AuthService : IAuthenticationService
    {
        public User Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public bool PasswordReset(string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public User Register(User userModel)
        {
            throw new NotImplementedException();
        }

        public User UpdateUser(User userModel)
        {
            throw new NotImplementedException();
        }
    }
}
