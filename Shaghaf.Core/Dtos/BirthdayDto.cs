using System;
using System.Collections.Generic;

namespace Shaghaf.Core.Dtos
{
    public class BirthdayDto
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public DateTime Date { get; set; }
        public int NumberOfGuests { get; set; }

        // Fields for Cake information
        public List<string> CakeNames { get; set; } = new List<string>();
        public List<decimal> CakePrices { get; set; } = new List<decimal>();

        // Fields for Decoration information
        public List<string> DecorationDescriptions { get; set; } = new List<string>();
        public List<decimal> DecorationPrices { get; set; } = new List<decimal>();

        // Fields for PhotoSession information
        public List<int> PhotoSessionIds { get; set; } = new List<int>();
        public List<decimal> PhotoSessionCosts { get; set; } = new List<decimal>();
        public List<TimeSpan> PhotoSessionDurations { get; set; } = new List<TimeSpan>();
        public List<DateTime> PhotoSessionDates { get; set; } = new List<DateTime>();
        public List<string> PhotoSessionLocations { get; set; } = new List<string>();

        public int RoomId { get; set; }
    }
}
