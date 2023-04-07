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

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
