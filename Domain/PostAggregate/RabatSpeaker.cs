using System.Runtime.Serialization;

namespace Domain.PostAggregate
{
    public enum RabatSpeaker
    {
        [EnumMember(Value = "Politician")]
        Politician,

        [EnumMember(Value = "Public Figure")]
        PublicFigure,

        [EnumMember(Value = "Private Person")]
        PrivatePerson
        
    }
}
