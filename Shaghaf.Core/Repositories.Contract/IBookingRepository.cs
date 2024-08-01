using Shaghaf.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaghaf.Core.Repositories.Contract
{
    public interface IBookingRepository : IGenericRepository<Booking>
    {
        Task<Booking> FindUniqueBookingAsync(int roomId, DateTime startDate, DateTime endDate, string customerName);
    }

}
