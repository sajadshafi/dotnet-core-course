using AuthBasic.Interfaces;
using AuthBasic.Repositories;

namespace AuthBasic.Helpers.ServicesRegisteration
{
    public static class RepositoryServices
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
