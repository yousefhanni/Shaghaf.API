using System.Runtime.Serialization;

namespace Shaghaf.Core.Entities.RoomEntities
{
    public enum RoomPlan
    {
        [EnumMember(Value = "Hour")]
        Hour,
        [EnumMember(Value = "Day")]
        Day,
        [EnumMember(Value = "Month")]
        Month
    }
}