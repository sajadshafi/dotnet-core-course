using Microsoft.EntityFrameworkCore;

namespace EfCore.Models {
    public class ApplicationDbContext : DbContext {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            string connectionString = "Data Source=DESKTOP-LGKQN1M\\SQLEXPRESS;Initial Catalog=BasicEF;Persist Security Info=True;User ID=sa;Password=malik@123;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
