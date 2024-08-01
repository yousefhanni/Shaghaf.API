using System.Runtime.Serialization;

namespace Shaghaf.Core.Entities.RoomEntities
{
    public enum RoomType
    {
        [EnumMember(Value = "TrainingRoom")]
        TrainingRoom,
        [EnumMember(Value = "FunnyRoom")]
        FunnyRoom,
        [EnumMember(Value = "MeetingRoom")]
        MeetingRoom
    }
}