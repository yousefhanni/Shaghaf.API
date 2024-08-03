using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaghaf.Core.Entities.HomeEntities
{
    public class Home:BaseEntity
    {
        public int LocationId { get; set; } // Foreign key
        public Location Location { get; set; }
        public string Heading { get; set; }
        public ICollection<Advertisement> Advertisements { get; set; }
        //public ICollection<Membership> Memberships { get; set; }
        //public ICollection<Birthday> Birthdays { get; set; }
      //  public ICollection<PhotoSession> PhotoSessions { get; set; }
        public ICollection<Category> Categories { get; set; }
      
    }
}
