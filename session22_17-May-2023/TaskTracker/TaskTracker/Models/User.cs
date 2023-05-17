using Microsoft.AspNetCore.Identity;

namespace TaskTracker.Models {
    public class SystemUser : IdentityUser<Guid> {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class SystemRole : IdentityRole<Guid> {
        public bool IsDeleted { get; set; }
    }
}
