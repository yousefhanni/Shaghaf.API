using Shaghaf.Core.Entities.RoomEntities;

namespace Shaghaf.Core.Entities.MembershipEntity
{
    //The Membership class is used to represent different types of memberships available for users in the system
    public class Membership : BaseEntity
    {
        public string Name { get; set; } = null!; // Name of the membership type
        public decimal Price { get; set; } // Cost of the membership
        public string Description { get; set; } = null!; // Description of what the membership includes
        public int DurationInDays { get; set; } // Duration of the membership in days
        public int MaxGuests { get; set; } // Maximum number of guests allowed
        //public bool IncludesDrinks { get; set; } // Whether the membership includes drinks
        //public bool IncludesMovieNights { get; set; } // Whether the membership includes movie nights

        // Navigation property if a membership can be linked to specific rooms or events
        public ICollection<Room> Rooms { get; set; } = new List<Room>(); // Rooms that are available with this membership
    }
}