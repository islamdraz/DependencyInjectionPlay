using System;

namespace DependencyInjectionPlay
{
    internal class ServiceDescriptor
    {
        public Type ServiceType { get;  }
        public Type ImplementationType { get;  }
        public object Implementation { get; internal set; }
        public LifeTime LifeTime { get;}

        public ServiceDescriptor(object implementation,LifeTime lifeTime)
        {
            ServiceType = implementation.GetType();
            Implementation = implementation;
            LifeTime = lifeTime;
        }
        public ServiceDescriptor(Type type, LifeTime lifeTime)
        {
            ServiceType = type;
            LifeTime = lifeTime;
        }

        public ServiceDescriptor(Type type,Type implementationtype, LifeTime lifeTime)
        {

            ServiceType = type;
            ImplementationType = implementationtype;
            LifeTime = lifeTime;
        }
    }
}