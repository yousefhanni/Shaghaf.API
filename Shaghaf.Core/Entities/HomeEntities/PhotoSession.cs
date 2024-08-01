namespace Shaghaf.Core.Entities.HomeEntities
{
    public class PhotoSession:BaseEntity
    {
        public DateTime Date { get; set; }
        public string Description { get; set; } // New property for additional information
        public decimal Price { get; set; } // New property for price
        public int HomeId { get; set; } // Foreign key
        public Home Home { get; set; }
    }
}