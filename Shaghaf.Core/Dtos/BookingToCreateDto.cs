using System;

namespace Shaghaf.Core.Dtos
{
    public class BookingToCreateDto
    {
        public int RoomId { get; set; }
        public int? BirthdayId { get; set; }
        public int? PhotoSessionId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CustomerName { get; set; } = null!;
        public int SeatCount { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; } = null!;
        public string SessionId { get; set; } = null!;
        public string Status { get; set; } = null!;
        public decimal Discount { get; set; }
    }
}
