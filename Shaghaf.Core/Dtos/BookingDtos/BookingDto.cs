using Shaghaf.Core.Entities.BookingEntities;

namespace Shaghaf.Core.Dtos.BookingDtos
{
    public class BookingDto
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int? BirthdayId { get; set; }
        public int? PhotoSessionId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public int SeatCount { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; } = string.Empty;
        public BookingStatus Status { get; set; }
        public decimal Discount { get; set; }
        public ICollection<OrderDto>? Orders { get; set; } // Optional associated orders
        public string PaymentIntentId { get; set; } = string.Empty; // Payment Intent ID
        public string SessionId { get; set; } = string.Empty; // Session ID
        public bool PaymentStatus { get; set; } // Payment status for polling
    }
}
