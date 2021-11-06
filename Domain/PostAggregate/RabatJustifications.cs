using System;

namespace Domain.PostAggregate
{
    [Flags]
    public enum RabatJustifications
    {
        Dehumanization = 0,
        GuiltAttribution = 1,
        ThreatConstruction = 2,
        DestructionAlternatives = 3,
        VirtueTalk = 4,
        FutureBias = 5
    }
}
