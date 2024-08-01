namespace Shaghaf.Core.Entities.HomeEntities
{
    //The Membership class is used to represent different types of memberships available for users in the system
    public class Membership:BaseEntity
    {
        public string Type { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int HomeId { get; set; } // Foreign key
        public Home Home { get; set; }
    }
}