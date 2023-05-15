# AspNet Core Identity Authentication and Authorization

[Click here to download the lecture](https://www.idrive.com/idrive/sh/sh?k=m5l9w3l2f5)

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


