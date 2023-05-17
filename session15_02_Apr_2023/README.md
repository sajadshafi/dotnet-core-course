# Session 15 - Dependency Injection using Autofac

[click here to download lecture video](https://www.idrive.com/idrive/sh/sh?k=z9y7m8p1y6)

Setting up dependency injection using autofac.

```C#
// ** Begin composition root
public static class Program
{
    public static void Main(string[] args) 
    {
        var container = ConfigureContainer();
        var application = container.Resolve<ApplicationLogic>();

        application.Run(args); // Pass runtime data to application here
    }

    private static IContainer ConfigureContainer()
    {
        var builder = new ContainerBuilder();
        
        builder.RegisterType<ApplicationLogic>.AsSelf();
        builder.RegisterType<Log>().As<ILog>();
        // Register all dependencies (and dependencies of those dependencies, etc)

        return builder.Build();
    }
}
// ** End composition root

public class ApplicationLogic
{
    private readonly ILog log;

    public ApplicationLogic(ILog log) => this.log = log;

    public void Run(string[] args) => this.log.Write("Hello, world!");
}
```
