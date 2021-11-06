using System;

namespace Domain.PostAggregate
{
    [Flags]
    public enum RabatDangerous
    {
        Content = 0,
        Context = 1,
        Medium = 2,
        
    }
}
