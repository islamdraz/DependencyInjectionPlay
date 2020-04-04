using System.Linq.Expressions;

namespace DependencyInjectionPlay
{
    class Program
    {
        static void Main(string[] args)
        {

            var services = new DiServiceCollection();
            //services.AddSingleton(new RandomGuidGenerator());
            // services.AddSingleton<RandomGuidGenerator>();
            //  services.AddTransiant<RandomGuidGenerator>();

            //services.AddTransiant<ISomeService,SomeService>();
            //services.AddTransiant<IGuidProvider,GuidProvider>();

            services.AddSingleton<ISomeService,SomeService>();
            services.AddTransiant<IGuidProvider,GuidProvider>();
            var container = services.GenerateDiContainer();

            //var firstService = container.GetService<RandomGuidGenerator>();
            //var sencodService = container.GetService<RandomGuidGenerator>();

            //Console.WriteLine(firstService.RandomGuid);
            //Console.WriteLine(sencodService.RandomGuid);

            var service1 = container.GetService<ISomeService>();
            var service2=container.GetService<ISomeService>();

            service1.PrintSomthing();
            service2.PrintSomthing();

        }
    }

    internal enum LifeTime
    {
        Singletone,
        Transiant
    }
}
