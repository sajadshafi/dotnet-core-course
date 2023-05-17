# Session 21 - Continuing Authentication and Authorization

[Download video lecture](https://www.idrive.com/idrive/sh/sh?k=l5o0a5d4v3)

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

- Configure \_layout

add `@await Component.InvokeAsync("NToastNotify")` to \_layout.cshtml

and finally use Toast message
Inject service `IToastNotification` and invoke different types of toastr messages