using Shaghaf.Core.Entities.BookingEntities;
using Shaghaf.Core.Entities.RoomEntities;
using System;

namespace Shaghaf.Core.Entities
{
    public class Booking : BaseEntity
    {
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CustomerName { get; set; }
        public int SeatCount { get; set; }
      //  public ICollection<AdditionalItem> AdditionalItems { get; set; } = new List<AdditionalItem>();

        // Payment-related fields
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string SessionId { get; set; }
        public BookingStatus Status { get; set; }

        // Discount-related fields
        public decimal Discount { get; set; }
    }
 
}
