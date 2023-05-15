using AuthBasic.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthBasic.Helpers.ServicesRegisteration {
    public static class DbServices { 
        public static IServiceCollection AddDbServices(this IServiceCollection services) {
            services.AddDbContext<TodoContext>(cfg => cfg.UseSqlServer("Data Source=DESKTOP-2IROM78;Initial Catalog=AuthBasic;Integrated Security=True;TrustServerCertificate=true;"));
            return services;
        }
    }
}
