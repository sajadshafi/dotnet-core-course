using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskTracker.IServices;
using TaskTracker.Models;
using TaskTracker.Services;

namespace TaskTracker {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            IConfiguration config = builder.Configuration;

            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(config.GetConnectionString("DbConnection")));

            builder.Services.AddIdentity<SystemUser, SystemRole>(
                cfg => {
                    //Password Configurations
                    cfg.Password.RequiredUniqueChars = 4;
                    cfg.Password.RequireNonAlphanumeric = false;
                    cfg.Password.RequireDigit = false;
                    cfg.Password.RequireUppercase = false;

                    //cfg.Lockout.MaxFailedAccessAttempts = 5;

                    //User Configurations
                    cfg.User.RequireUniqueEmail = true;
                    //cfg.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvABCDEF._";
                }
           )
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddNToastNotifyToastr(new NToastNotify.ToastrOptions {
                TimeOut = 4000,
                CloseButton = true,
                ProgressBar = true,
            });


            //Custom Services
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ITaskRepository, TaskRepository>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment()) {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseNToastNotify();

            app.MapControllerRoute(
                name: "admin",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}