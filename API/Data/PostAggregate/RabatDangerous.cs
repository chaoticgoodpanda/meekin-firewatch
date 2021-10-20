using System;

namespace API.Data.PostAggregate
{
    [Flags]
    public enum RabatDangerous
    {
        Content = 0,
        Context = 1,
        Medium = 2,
        
    }
}
