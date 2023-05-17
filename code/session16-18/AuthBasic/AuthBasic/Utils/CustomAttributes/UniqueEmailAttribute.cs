using AuthBasic.Models;
using System.ComponentModel.DataAnnotations;

namespace AuthBasic.Utils.CustomAttributes {
    public class UniqueEmailAttribute : ValidationAttribute {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
            TodoContext _context = validationContext.GetService<TodoContext>();

            bool emailExists = _context.Users.Any(u => u.Email == value.ToString());

            if (!emailExists) return ValidationResult.Success;

            else return new ValidationResult(ErrorMessage ?? "Email already exists");
        }
    }
}
