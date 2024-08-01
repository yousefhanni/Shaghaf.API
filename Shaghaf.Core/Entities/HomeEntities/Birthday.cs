namespace Shaghaf.Core.Entities.HomeEntities
{
    public class Birthday:BaseEntity
    {
        public string Name { get; set; } //This represents the title or designation for the birthday event,for example, "John's Birthday.
        public DateTime Date { get; set; }//: The specific date when the birthday event is scheduled to occur.
        public string Description { get; set; } // New property for additional information
        public ICollection<Cake> Cakes { get; set; }
        public ICollection<Decoration> Decorations { get; set; }
        public int HomeId { get; set; } // Foreign key
        public Home Home { get; set; }
    }
}