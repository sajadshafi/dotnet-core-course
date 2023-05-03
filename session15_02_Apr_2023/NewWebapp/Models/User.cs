using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewWebapp.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ImageUrl { get; set; }
        public string Password { get; set; }

        //keys
        //public Guid RoleId { get; set; }

        public Role Role { get; set; }
    }
}
