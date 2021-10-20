using System.Runtime.Serialization;

namespace API.Data.PostAggregate
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
