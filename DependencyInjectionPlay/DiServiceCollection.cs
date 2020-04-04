using System.Collections.Generic;

namespace DependencyInjectionPlay
{
    internal class DiServiceCollection
    {
        List<ServiceDescriptor> registeredServices=new List<ServiceDescriptor>();
        public void AddSingleton<ServiceT>(ServiceT implementation)
        {
            registeredServices.Add(new ServiceDescriptor(implementation , LifeTime.Singletone));

        }

        public void AddSingleton<ServiceT>()
        {
            registeredServices.Add(new ServiceDescriptor(typeof(ServiceT), LifeTime.Singletone));

        }

        public void AddTransiant<ServiceT>()
        {
            registeredServices.Add(new ServiceDescriptor(typeof(ServiceT), LifeTime.Transiant));

        }

        public void AddTransiant<InterfaceT,ImplementationT>() where ImplementationT : InterfaceT
        {
            registeredServices.Add(new ServiceDescriptor(typeof(InterfaceT), typeof(ImplementationT), LifeTime.Transiant));

        }

        public void AddSingleton<InterfaceT, ImplementationT>() where ImplementationT : InterfaceT
        {
            registeredServices.Add(new ServiceDescriptor(typeof(InterfaceT), typeof(ImplementationT), LifeTime.Singletone));

        }


        public DiContainer GenerateDiContainer()
        {
            return new DiContainer(registeredServices);
        }
    }
}