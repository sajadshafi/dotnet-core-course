# Session 01 - Entity Framework Core

[Click to download the lecture video here](https://www.idrive.com/idrive/sh/sh?k=x2y3f2z3u5)

## Introduction
Entity Framework (EF) Core is a lightweight, extensible, open source and cross-platform version of the popular Entity Framework data access technology. 
The Entity Framework enables you to query, insert, update, and delete data, using Common Language Runtime (CLR) objects known as entities. The Entity Framework maps the entities and relationships that are defined in your model to a database.

EF Core can serve as an object-relational mapper (O/RM), which:
- Enables .NET developers to work with a database using .NET objects.
- Eliminates the need for most of the data-access code that typically needs to be written.

EF Core supports many database engines, see [Database Providers](https://learn.microsoft.com/en-us/ef/core/providers/) for details.

## Context class
The primary class that is responsible for interacting with data as objects is the DbContext. The recommended way to work with context is to define a class that derives from the DbContext and exposes the DbSet properties that represent collections of the specified entities in the context.
Logically, a DBContext maps to a specific database that has a schema that the DBContext understands. And on that DBContext class, you can create properties that are type DbSet<T>. The generic type parameter T will be a type of entity, e.g: Employee, Student or any other database model.

```CSharp
public class ApplicationDbContext : DbContext {  
    public DbSet<Post> Posts { get; set; }  
}
```

## Model
With EF Core, data access is performed using a model. A model is made up of entity classes and a context object that represents a session with the database. The context object allows querying and saving data.

```CSharp
public class Post { 
    public int Id { get; set; } 
    public string Title { get; set; } 
    public string Content { get; set; } 
	public bool IsPublished { get; set; }
	public DateTime PublishDate { get; set; }
}
```

## Querying

Instances of your entity classes are retrieved from the database using  [Language Integrated Query (LINQ)](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/).

```CSharp
using (var db = new ApplicationDbContext())
{
    var blogs = await _db.Posts
        .Where(b => b.IsPublished > true)
        .OrderByDescending(b => b.PublishDate)
        .ToListAsync();
}
```

## Saving data

Data is created, deleted, and modified in the database using instances of your entity classes.
```CSharp
using (var db = new BloggingContext())
{
    var post = new Post {
        Title = "Some article title",
        Content = "content of the post",
        IsPublished = false,
        PublishDate = null 
    };
    await _db.Posts.Add(post);
    await db.SaveChangesAsync();
}
```