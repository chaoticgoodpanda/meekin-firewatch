using System.Runtime.Serialization;

namespace API.Data.PostAggregate
{
    public enum RabatIntent
    {
        [EnumMember(Value = "Intentional")]
        Intentional,
        [EnumMember(Value = "Reckless")]
        Reckless,
        [EnumMember(Value = "Negligent")]
        Negligent,
        [EnumMember(Value = "Strict Liability")]
        StrictLiability,
        [EnumMember(Value = "None")]
        None
    }
}
