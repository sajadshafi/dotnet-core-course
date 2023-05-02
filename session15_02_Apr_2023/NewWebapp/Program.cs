using Microsoft.EntityFrameworkCore;
using NewWebapp.IServices;
using NewWebapp.Models;
using NewWebapp.Services;

namespace NewWebapp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var config = builder.Configuration;

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        //Add Db service
        builder.Services.AddDbContext<ApplicationDbContext>(
            options => options.UseSqlServer(config.GetConnectionString("DefaultConnection"))
        );

        //Custom services
        builder.Services.AddScoped<IAuthenticationService, AuthService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
