using AuthBasic.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthBasic.Helpers.ServicesRegisteration {
    public static class DbServices { 
        public static IServiceCollection AddDbServices(this IServiceCollection services) {
            services.AddDbContext<TodoContext>(cfg => cfg.UseSqlServer("Data Source=DESKTOP-LGKQN1M\\SQLEXPRESS;Initial Catalog=AuthBasic;User ID=sa;Password=malik@123;TrustServerCertificate=true;"));
            return services;
        }
    }
}
