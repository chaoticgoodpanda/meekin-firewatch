using System;

namespace Domain.PostAggregate
{
    [Flags]
    public enum RabatOffensive
    {
        None = 0,
        Worried = 1,
        Unhappy = 2,
        Angry = 3
        
    }
}
