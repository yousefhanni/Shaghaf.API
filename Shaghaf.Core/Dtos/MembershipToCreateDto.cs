using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaghaf.Core.Dtos
{
    public class MembershipToCreateDto
    {
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;
        public int DurationInDays { get; set; }
        public int MaxGuests { get; set; }
        public ICollection<int> RoomIds { get; set; } = new List<int>();
    }
}
