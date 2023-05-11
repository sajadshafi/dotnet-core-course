using AuthBasic.Helpers.ServicesRegisteration;
using Microsoft.AspNet.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();
builder.Services.AddDbServices();
builder.Services.AddRepositoryServices();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = DefaultAuthenticationTypes.ApplicationCookie;
})
        .AddCookie(DefaultAuthenticationTypes.ApplicationCookie, options => {

            options.LoginPath = "/User/Login";
            options.LogoutPath = "/User/Logout";
        });

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

//app.UseAuthentication();
app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
