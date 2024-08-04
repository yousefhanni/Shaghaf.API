using System.Collections.Generic;
using System.Threading.Tasks;
using Shaghaf.Core.Dtos;

namespace Shaghaf.Core.Services.Contract
{
    public interface IBookingService
    {
        Task<BookingDto> CreateBookingAsync(BookingToCreateDto bookingToCreateDto);
        Task UpdateBookingAsync(BookingDto bookingDto);
        Task<BookingDto?> GetBookingDetailsAsync(int bookingId);
        Task<IReadOnlyList<BookingDto>> GetAllBookingDetailsAsync();
    }
}
