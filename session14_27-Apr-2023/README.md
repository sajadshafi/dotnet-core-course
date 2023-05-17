## Session 14 - Abstraction, Interfaces and Abstract classes, Dependency Injection

[Download Video lecture here](https://www.idrive.com/idrive/sh/sh?k=v9s1f5f2h5)

### Abstraction

Abstraction is the process of hiding the internal details of an application from the outer world. Abstraction is used to describe things in simple terms. It’s used to create a boundary between the application and the client programs.

### Abstract classes

A class which is declared as abstract is known as an abstract class. It can have abstract and non-abstract methods. **Abstract Method** can be defined as a method that doesn't have the implementation. Abstract classes can be instantiated.

### Interfaces

Interface is just like a class but it only contains **Abstract Method** and if a class inherits from interface then that class must implement all the methods inside interface which is not the case with abstract classes. In abstract classes we can skip implementation of some abstract methods.

### Coupling and Cohesian:

Coupling - Dependency between two different modules
loosely coupling is recommended - Unit testing should be easy.

Cohesian - Dependency of small items with in a module
High Cohesian - recommended

### Dependency Injection or IoC - (Inversion of Control)

Dependency Injection (DI) is a software design pattern that allows us to develop loosely-coupled code that is easy to maintain.

Dependency Injection pattern enforces a simple statement:

'New is glue'

Don't create your dependencies inside of your objects, and instead prefer them to be injected by an outside manager. This outside manager is typically another class that is referred to as a Service Locator or a Container. You'll see this technique referred to as Inversion of Control as you are giving control of the creation of the dependencies to another object that will be maintaining them for you.

Dependency Injection comes in several forms:

- Constructor Injection
  - The most common and requires that dependencies be provided in the constructor of a class
- Property Injection
  - Allows dependencies to be optionally set through properties on a class
- Method Injection
  - Dependencies are provided only on the methods where they are interacted with at the time they are executed

### Service lifetimes

Services can be registered with one of the following lifetimes:

- Transient
- Scoped
- Singleton

#### 1 - Transient

Transient lifetime services are created each time they're requested from the service container. This lifetime works best for lightweight, stateless services. Register transient services with AddTransient.

In apps that process requests, transient services are disposed at the end of the request.

#### 2 - Scoped

For web applications, a scoped lifetime indicates that services are created once per client request (connection). Register scoped services with AddScoped.

In apps that process requests, scoped services are disposed at the end of the request.

When using Entity Framework Core, the AddDbContext extension method registers DbContext types with a scoped lifetime by default.

#### 3 - Singleton

Singleton lifetime services are created either:

The first time they're requested.
By the developer, when providing an implementation instance directly to the container. This approach is rarely needed.
Every subsequent request of the service implementation from the dependency injection container uses the same instance. If the app requires singleton behavior, allow the service container to manage the service's lifetime. Don't implement the singleton design pattern and provide code to dispose of the singleton. Services should never be disposed by code that resolved the service from the container. If a type or factory is registered as a singleton, the container disposes the singleton automatically.

Register singleton services with AddSingleton. Singleton services must be thread safe and are often used in stateless services.

In apps that process requests, singleton services are disposed when the ServiceProvider is disposed on application shutdown. Because memory is not released until the app is shut down, consider memory use with a singleton service.

### Dependency Injection container providers:

Almost all the dependency containers have same way of implementation. In this we will look into two of the most used DI containers which is Microsoft.Extensions.DependencyInjection and Autofac and all others follow almost same procedure

#### 1 - Microsoft DependencyInjection

```csharp

//Configure Dependency Injection Container

IHost host = Host.CreateDefaultBuilder()
.ConfigureServices((_, services) => {
    services.AddSingleton<IStartup, Startup>();

    services.AddTransient<ISomething, Something>();
}).Build();
//
// var svc = ActivatorUtilities.CreateInstance<Startup>(host.Services);
// svc.Run();

```

#### 2 - Autofac

#### 3 - NInject
