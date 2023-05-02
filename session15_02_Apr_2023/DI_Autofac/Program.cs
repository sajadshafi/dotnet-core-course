using Autofac;
using DI_Autofac.IServices;
using DI_Autofac.Models;
using DI_Autofac.Services;

namespace DI_Autofac
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var container = new ContainerBuilder();
            container.RegisterType<StudentService>().As<IStudentService>();

            container.RegisterType<Startup>().AsSelf();

            var cont = container.Build();

            //Execute all rest code

            var startup = cont.Resolve<Startup>();

            startup.Run();
        }
    }

    public class Startup
    {
        private readonly IStudentService service;

        public Startup(IStudentService service)
        {
            this.service = service;
        }

        public void Run()
        {
            this.service.SaveStudent(new Student());
        }
    }
}
