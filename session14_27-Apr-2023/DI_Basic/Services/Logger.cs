using DI_Basic.Interfaces;

namespace DI_Basic.Services
{
    public class Logger : ILogger
    {
      public void Log()
      {
          string message = "This is a simple log!";
          Console.WriteLine(message);
      }
    }
}
