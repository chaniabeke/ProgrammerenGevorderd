using System.Runtime.Serialization;

namespace Covid19
{
    public enum Sex
    {
        [EnumMember(Value = "F")]
        Female,
        [EnumMember(Value = "M")]
        Male
    }
}