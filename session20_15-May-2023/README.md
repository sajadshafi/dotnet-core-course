# Continuing Authentication and Authorization


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