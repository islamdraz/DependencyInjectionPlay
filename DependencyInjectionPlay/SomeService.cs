using System;

namespace DependencyInjectionPlay
{
    internal class SomeService:ISomeService
    {
        private readonly IGuidProvider _guidProvider;

        public SomeService(IGuidProvider guidProvider)
        {
            _guidProvider = guidProvider;
        }
       // private readonly Guid RandomGuid = Guid.NewGuid();
        public void PrintSomthing()
        {
            Console.WriteLine(_guidProvider.RandomGuid);
            //Console.WriteLine(RandomGuid);
        }
    }

    internal interface IGuidProvider
    {
        Guid RandomGuid { get; }
    }

    internal class GuidProvider:IGuidProvider
    {
        public Guid RandomGuid { get; } = Guid.NewGuid();
    }
}