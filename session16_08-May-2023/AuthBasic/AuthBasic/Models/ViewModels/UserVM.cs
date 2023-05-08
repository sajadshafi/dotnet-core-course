using System.ComponentModel.DataAnnotations;

namespace AuthBasic.Models.ViewModels {
    public class UserVM {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required, EmailAddress(ErrorMessage="Email is not a valid address")]
        public string Email { get; set; }
        public string Password { get; set; }

        [Compare("Password", ErrorMessage="confirm password not match")]
        public string ConfirmPassword { get; set; }
        public string Username { get; set; }


        #region mappers
        public static void MapUserVMToEntity(UserVM source, User destination) {
            if(source.Id != null)
                destination.Id = (Guid)source.Id;
            destination.Username = source.Username;
            destination.Email = source.Email;
            destination.Password =  source.Password;
            destination.Name = source.Name;
        }

        public static void MapEntityToUserVM(User source, UserVM destination) {
            destination.Id = source.Id;
            destination.Username = source.Username;
            destination.Email = source.Email;
            destination.Password = source.Password;
            destination.Name = source.Name;
        }
        #endregion
    }


    public class LoginVM {
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
    }

}
