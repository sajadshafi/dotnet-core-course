using NewWebapp.Models;

namespace NewWebapp.IServices
{
    public interface IAuthenticationService
    {
        /// <summary>
        /// Login a user with email and password
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        User Login(string email, string password);
        User Register(User userModel);
        bool PasswordReset(string oldPassword, string newPassword);
        User UpdateUser(User userModel);
    }
}