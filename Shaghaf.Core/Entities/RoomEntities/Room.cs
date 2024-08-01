

using System.ComponentModel.DataAnnotations.Schema;

namespace Shaghaf.Core.Entities.RoomEntities
{
    public class Room :BaseEntity
    {
        public string Name { get; set; } = null!;
        public decimal Offer { get; set; }
        public decimal Rate { get; set; }
        public int Seat { get; set; }
        public string Description { get; set; } = null!;

     
     //   public ICollection<string> Amenities { get; set; }

        public string Location { get; set; } = null!;
        public DateTime Date { get; set; }

        public decimal Price { get; set; }

        public RoomPlan Plan { get; set; } = RoomPlan.Hour; // default is per hour


        public RoomType Type { get; set; } = RoomType.FunnyRoom; // default is funny

    }
}
