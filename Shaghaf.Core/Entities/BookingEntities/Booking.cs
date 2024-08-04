    using Shaghaf.Core.Entities.BirthdayEntity;
    using Shaghaf.Core.Entities.HomeEntities;
    using Shaghaf.Core.Entities.RoomEntities;

    namespace Shaghaf.Core.Entities.BookingEntities
    {
        public class Booking : BaseEntity
        {
            public DateTime StartDate { get; set; } // Start date of the booking
            public DateTime EndDate { get; set; } // End date of the booking
            public string CustomerName { get; set; } = null!; // Name of the customer
            public int SeatCount { get; set; } // Number of seats booked
            public decimal Amount { get; set; } // Total amount for the booking
            public string Currency { get; set; } = null!; // Currency of the amount
            public string SessionId { get; set; } = null!; // Session ID for the booking
            public BookingStatus Status { get; set; } // Status of the booking
            public decimal Discount { get; set; } // Discount applied to the booking

            public int RoomId { get; set; } // ID of the booked room
            public Room Room { get; set; } = null!; // Associated room

            public int? BirthdayId { get; set; } // ID of the associated birthday event (optional)
            public Birthday? Birthday { get; set; } // Associated birthday event (optional)

            public int? PhotoSessionId { get; set; } // ID of the associated photo session (optional)
            public PhotoSession? PhotoSession { get; set; } // Associated photo session (optional)
        }
    }