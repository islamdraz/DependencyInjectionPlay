using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace DependencyInjectionPlay
{
    internal class DiContainer
    {
        private List<ServiceDescriptor> _services;

        public DiContainer(List<ServiceDescriptor> services)
        {
            _services = services;
        }

        private object GetService(Type type)
        {
            var descriptor = _services.FirstOrDefault(x => x.ServiceType == type);

            if (descriptor == null)
            {
                throw new Exception($"service of type {type.Name} doesn't have implementation");
            }

            if (descriptor.Implementation != null)
            {
                return descriptor.Implementation;
            }

            var actualType = descriptor.ImplementationType ?? descriptor.ServiceType;
            if (actualType.IsAbstract || actualType.IsInterface)
            {
                throw new Exception("can't instantiate abstract class or interface");
            }
            var constructorInfo = actualType.GetConstructors().First();                                     

            var parameters = constructorInfo.GetParameters().Select(x => GetService(x.ParameterType) ).ToArray();

            var implementation = Activator.CreateInstance(actualType,parameters);
                
            if (descriptor.LifeTime == LifeTime.Singletone)
                descriptor.Implementation = implementation;

            return implementation;

        }

        public T GetService<T>()
        {

            return (T) GetService(typeof(T) );
        }
    }
}