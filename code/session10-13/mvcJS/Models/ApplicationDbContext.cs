using Microsoft.EntityFrameworkCore;

namespace mvcJS.Models {
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
        public DbSet<Employee> Employees { get; set; }
    }
}
