using Microsoft.EntityFrameworkCore;
using Shaghaf.Core.Entities;
using Shaghaf.Core.Repositories.Contract;
using Shaghaf.Infrastructure.Data;
using Shaghaf.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaghaf.Infrastructure.Sevices.Implementaion
{
    public class BookingRepository : GenericRepository<Booking>, IBookingRepository
    {
        public BookingRepository(StoreContext context) : base(context)
        {
        }

        public async Task<Booking> FindUniqueBookingAsync(int roomId, DateTime startDate, DateTime endDate, string customerName)
        {
            return await _context.Bookings.FirstOrDefaultAsync(b =>
                b.RoomId == roomId &&
                b.StartDate >= startDate &&
                b.StartDate <= endDate &&
                b.CustomerName == customerName);
        }
    }

}
