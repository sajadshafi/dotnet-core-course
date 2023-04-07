# Session 03 - Database connectivity and configurations

[Click here to download the lecture for this session](https://www.idrive.com/idrive/sh/sh?k=e6c8w8r8l5)

## Introduction
In this session we will look at _Layouts, passing data to views, and DbConnectivity.

### What is _Layout.cshtml
The _Layout page is a special type of view in ASP.NET MVC that defines the common layout for all other views in your application. It typically contains the HTML markup that defines the structure of your application's pages, including the header, navigation, footer, and other common elements.

The _Layout page is usually stored in the "Views/Shared" folder and is named "_Layout.cshtml". This naming convention is important because it tells ASP.NET MVC that this view should be used as the default layout for all other views in your application. You can also define multiple layout pages and specify which one to use for a specific view.

The _Layout page uses Razor syntax to define the layout and can include other views or partial views to define different parts of the page. A typical _Layout file will look like this:
```HTML
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewData["Title"]</title>
</head>
<body>
    <div class="container">
        <header>
            <nav>
                <ul>
                    <li>@Html.ActionLink("Home", "Index", "Home")</li>
                    <li>@Html.ActionLink("Products", "Index", "Products")</li>
                    <li>@Html.ActionLink("Contact", "Index", "Contact")</li>
                </ul>
            </nav>
        </header>
        <div class="main-content">
            @RenderBody()
        </div>
        <footer>
            <p>&copy; 2023 My Website</p>
        </footer>
    </div>
    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/bootstrap")
    @RenderSection("scripts", required: false)
</body>
</html>
```

The `@RenderBody()` method renders the rest of the page that will be wrapped by this layout.

### appsettings.json
In an ASP .NET Core application, appsettings.json is a configuration file used to store application-specific settings such as database connection strings, API keys, and other configuration options. The appsettings.json file is a JSON file that resides in the root directory of the project.
simple `appsettings` file looks like this:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=MyDatabase;Trusted_Connection=True;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AppSettings": {
    "ApiKey": "my-api-key",
    "BaseUrl": "https://api.example.com",
    "MaxItemsPerPage": 20
  }
}

```
To access values from the appsettings.json file in your application, you can use the IConfiguration interface. Here's an example of how to access the MaxItemsPerPage value from the AppSettings section:

```CSharp
public class SomeController : Controller {
    private readonly IConfiguration _config;
    public SomeController(IConfiguration config) {
        _config = config;
    }
    public IActionResult Index() {
        int maxItemsPerPage = _config.GetValue<int>("AppSettings:MaxItemsPerPage");
        // Use the maxItemsPerPage value in your code...
        return View();
    }
}
```

`_config.GetValue<int>("AppSettings:MaxItemsPerPage")` fetches the MaxItemsPerPage.

### Database connectivity
To get started, you'll need to install the Microsoft.EntityFrameworkCore.SqlServer NuGet package. You can do this using the NuGet Package Manager in Visual Studio, or by adding the package to your project's dependencies in the project.json file.
Now create a `csharp` file named `ApplicationDbContext` or we can name it anything.
```Csharp
using Microsoft.EntityFrameworkCore;
public class ApplicationDbContext : DbContext {
	private  readonly  IConfiguration _config;
	public  ApplicationDbContext(IConfiguration configuration) {
		_config  =  configuration;
	}
	protected override void OnConfiguring(DbContextOptionsBuilder options) {
		options.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
		base.OnConfiguring(options);
	}
	
    public  DbSet<Student> Students { get; set; }
	public  DbSet<Course> Courses { get; set; }
}
```

The `OnConfiguring` method configures the database using the **ConnectionString** from appsettings.json. And `DbSet<T>` is a mapping between the `T` object and the database table. `T` can be any entity with some property that you want to map with the database table.

after adding the models to the dbcontext class we can run migrations:
from `dotnet cli`
if you want to run using `dotnet cli` you might need to install `dotnet-ef`.
you can do that running the command `dotnet tool install --global dotnet-ef`
- dotnet migrations add "AddedStudentTable"
- dotnet migrations database update

or from `package manager console` of visual studio
- `add-migration` "migration_name"
- `update-database`