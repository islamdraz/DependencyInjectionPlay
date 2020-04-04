using System;

namespace DependencyInjectionPlay
{
    internal class RandomGuidGenerator
    {
        public Guid RandomGuid { get; set; } = Guid.NewGuid();
    }
}