namespace Shaghaf.Core.Dtos
{
    public class BookingToCreateDto
    {
        public int RoomId { get; set; }
        public int? BirthdayId { get; set; }
        public int? PhotoSessionId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public int SeatCount { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public decimal Discount { get; set; }
        public string PaymentIntentId { get; set; } = string.Empty;
        public string SessionId { get; set; } = string.Empty;
        public bool PaymentStatus { get; set; }
        public ICollection<OrderDto>? Orders { get; set; } // Optional associated orders
    }
}
