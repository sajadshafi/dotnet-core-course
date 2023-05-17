# Session 02 - Overview of MVC Architechture

[Click here to download the Video Lecture](https://www.idrive.com/idrive/sh/sh?k=c7c7y9d2c2)

# Introduction
The Model-View-Controller (MVC) architectural pattern separates an application into three main groups of components: Models, Views, and Controllers. This pattern helps to achieve [separation of concerns](https://learn.microsoft.com/en-us/dotnet/standard/modern-web-apps-azure-architecture/architectural-principles#separation-of-concerns). Using this pattern, user requests are routed to a Controller which is responsible for working with the Model to perform user actions and/or retrieve results of queries. The Controller chooses the View to display to the user, and provides it with any Model data it requires.

#### Structure of MVC
There are typically 3 folders:
- Controllers
- Views
- Models

A **controller** should reside inside *Controllers* folder and its name must be suffixed with Controller, then we should create a folder with that same name as controller inside the views folder. e.g: If we create a controller and name it **ProductsController**, the we should create a folder inside the *Views* folder and name it **Products**.
Then, for each action method inside a controller that returns a View(), we should create a razor page with the same name inside that folder that we created inside **Views** folder. e.g: Inside ProductsController we can have a method named **Index()** that returns a View then we should create a File named **Index.cshtml** insde **Products** folder of the Views.

## Model
In .NET Core, the model represents the data and business logic of the application. It can be defined using Entity Framework Core, which is an Object-Relational Mapping (ORM) framework that allows developers to interact with the database using .NET objects. Entity Framework Core provides a set of APIs that enable developers to define the data model, map it to the database schema, and perform CRUD operations.

####  Defining a Model

```CSharp
public class Product {
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
}
```
In this example, we define a model called "Product" with four properties: Id, Name, Price, and Description.

## View
In .NET Core, the view represents the user interface of the application. It can be defined using Razor, which is a syntax for creating dynamic HTML pages using C#. Razor allows developers to write server-side code that generates HTML, making it easier to render the data from the model.
Views are responsible for presenting content through the user interface. They use the [Razor view engine](https://learn.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-7.0#razor-view-engine) to embed .NET code in HTML markup. There should be minimal logic within views, and any logic in them should relate to presenting content.

#### Defining a View
```HTML
@model List<Product>

<h1>Products</h1>
<table>
    <thead>
        <tr>
            <th>Id</th>
            <th>Name</th>
            <th>Price</th>
            <th>Description</th>
        </tr>
    </thead>
    <tbody>
        @foreach (var product in Model)
        {
            <tr>
                <td>@product.Id</td>
                <td>@product.Name</td>
                <td>@product.Price</td>
                <td>@product.Description</td>
            </tr>
        }
    </tbody>
</table>
```
In this example, we define a view that displays a list of products. The view uses Razor syntax to iterate over the list of products and display their properties in an HTML table.

## Controller
In .NET Core, the controller handles the user's requests and manages the flow of data between the model and the view. It can be defined using ASP.NET Core, which is a web framework that provides a set of APIs for building web applications. ASP.NET Core allows developers to define the routing rules, handle the HTTP requests, and return the responses.
Controllers handle user interaction, work with the model, and ultimately select a view to render. In an MVC application, the view only displays information; the controller handles and responds to user input and interaction. In the MVC pattern, the controller is the initial entry point, and is responsible for selecting which model types to work with and which view to render (hence its name - it controls how the app responds to a given request).

#### Defining a Controller
```CSharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class ProductsController : Controller {
    private readonly ApplicationDbContext _context;
    public ProductsController(ApplicationDbContext context) {
        _context = context;
    }
    public async Task<IActionResult> Index() {
        List<Product> products = await _context.Products.ToListAsync();
        return View(products);
    }
}
```

In this example, we define a controller called "ProductsController" with one action method called "Index". The action method retrieves a list of products from the database using Entity Framework Core and passes it to the view.