# AspNet Core Identity Authentication and Authorization

[Click here to download the lecture]()

## Packages required

- Microsoft.AspNetCore.Identity.EntityFrameworkCore
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools

## Service Registration

```cs
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(_config.GetConnectionString("DbConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(cfg => {
    cfg.Lockout.MaxFailedAccessAttempts = 5;
    //User options
    //password options
})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
```

## Add Middlewares

```cs
useAuthentication();
useAuthorization();
```


## Inject

Inject `UserManager` and `SignInManager` to manage login and register functionalities

## Configuring Toast messaging (Optional)

```cs
//Adding service
builder.Services.AddControllersWithViews()
                .AddNToastNotifyToastr(new ToastrOptions {
                ProgressBar = true,
                CloseButton = true,
                TimeOut = 4000
            });


//use middleware
 app.UseNToastNotify();
```

- Configure _layout

add `@await Component.InvokeAsync("NToastNotify")` to _layout.cshtml

and finally use Toast message
Inject service `IToastNotification` and invoke different types of toastr messages