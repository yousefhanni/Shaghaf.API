using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shaghaf.Core.Entities.BookingEntities
{
    public enum BookingStatus
    {
        [EnumMember(Value = "Pending")]
        Pending,
        [EnumMember(Value = "Confirmed")]
        Confirmed,
        [EnumMember(Value = "Cancelled")]
        Cancelled,
        [EnumMember(Value = "Failed")]
        Failed // New status added here
    }


}

