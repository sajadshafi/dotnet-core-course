using DI_Basic.Interfaces;
using DI_Basic.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DI_Basic;

class Program
{
    static void Main(string[] args)
    {
        IHost host = Host.CreateDefaultBuilder()
            .ConfigureServices(
                (_, services) =>
                {
                    services.AddScoped<ILogger, Logger>();
                    services.AddScoped<ICustomerService, CustomerService>();
                }
            )
            .Build();

        var svc = ActivatorUtilities.CreateInstance<Startup>(host.Services);
        svc.Execute();
    }
}

public class Startup
{
    private readonly ILogger _log;
    private readonly ICustomerService customerService;

    public Startup(ILogger log, ICustomerService customerService)
    {
        _log = log;
        this.customerService = customerService;
    }

    public void Execute()
    {
        _log.Log();

        this.customerService.Amount = 200;
        Console.WriteLine("\nDiscounted Amount is: {0}", this.customerService.CalcluateDiscount(5));

        //Ambiguity found multiple methods of same name from multiple inherited classes
        //_log.LogLevel();
    }
}


/*
abstraction

Interface -> Customer Interface
Class -> implements interface and gives implementation to its methods

*/
