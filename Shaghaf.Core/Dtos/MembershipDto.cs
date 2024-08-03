using System.Collections.Generic;

namespace Shaghaf.Core.Dtos
{
    public class MembershipDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;
        public int DurationInDays { get; set; }
        public int MaxGuests { get; set; }
        //public bool IncludesDrinks { get; set; }
        //public bool IncludesMovieNights { get; set; }
        public ICollection<int> RoomIds { get; set; } = new List<int>();
    }
}
