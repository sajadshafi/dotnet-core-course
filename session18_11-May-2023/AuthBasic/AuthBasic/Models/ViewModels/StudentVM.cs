using AuthBasic.Utils.CustomAttributes;
using System.ComponentModel.DataAnnotations;

namespace AuthBasic.Models.ViewModels
{
    public class StudentVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required, EmailAddress(ErrorMessage = "Email is not a valid address")]
        [UniqueEmail]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }

        #region mappers
        public static void MapUserVMToEntity(StudentVM source, Student destination)
        {
            if (source.Id != null)
                destination.Id = source.Id;
            destination.Name = source.Name;
            destination.Email = source.Email;
            destination.Phone = source.Phone;
            destination.Address = source.Address;
        }

        public static void MapEntityToUserVM(Student source, StudentVM destination)
        {
            destination.Id = source.Id;
            destination.Name = source.Name;
            destination.Email = source.Email;
            destination.Phone = source.Phone;
            destination.Address = source.Address;
        }
        #endregion
    }
}

