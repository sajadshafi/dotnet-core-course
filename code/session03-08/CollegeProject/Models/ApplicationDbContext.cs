using Microsoft.EntityFrameworkCore;

namespace CollegeProject.Models {
    public class ApplicationDbContext : DbContext {
        private readonly IConfiguration _config;
        public ApplicationDbContext(IConfiguration configuration) {
            _config = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            options.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
            base.OnConfiguring(options);
        }

        /// <summary>
        /// Thsi is a student table where i can add students and delete them
        /// </summary>
        /// <value></value>
        public DbSet<Student> Students { get; set; }

        /// <summary>
        /// This is a course table where we mention fee and can delete / edit courses
        /// </summary>
        /// <value></value>
        public DbSet<Course> Courses { get; set; }
    }
}
