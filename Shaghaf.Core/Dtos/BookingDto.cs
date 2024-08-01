using Shaghaf.Core.Entities.BookingEntities;

namespace Shaghaf.Core.Dtos
{
    public class BookingDto
    {
        // add Status
        public int RoomId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CustomerName { get; set; }
        public int SeatCount { get; set; }
        public string Status { get; set; }
        public decimal Discount { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string SessionId { get; set; }
    }
}
