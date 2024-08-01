namespace Shaghaf.Core.Entities.HomeEntities
{
    public class Advertisement:BaseEntity
    {
        // add Price and remove DetailsUrl

        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime EventDate { get; set; }
        //public string DetailsUrl { get; set; }
        public int HomeId { get; set; } // Foreign key
        public Home Home { get; set; }

        

        public decimal Price { get; set; } 
    }
}