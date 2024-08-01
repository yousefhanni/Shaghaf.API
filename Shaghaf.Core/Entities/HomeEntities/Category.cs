namespace Shaghaf.Core.Entities.HomeEntities
{
    public class Category:BaseEntity
    {
        // will category contains rooms??

        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int HomeId { get; set; } // Foreign key
        public Home Home { get; set; }
    }
}