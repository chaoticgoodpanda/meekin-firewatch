using System;

namespace API.Data.PostAggregate
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
