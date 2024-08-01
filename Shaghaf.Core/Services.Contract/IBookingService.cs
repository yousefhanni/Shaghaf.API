using Shaghaf.Core.Dtos;
using Shaghaf.Core.Entities;
using Shaghaf.Core.Entities.BookingEntities;
using System.Threading.Tasks;

namespace Shaghaf.Core.Services.Contract
{
    public interface IBookingService
    {
        Task<BookingDto> CreateBookingAsync(BookingDto bookingDto);
        Task UpdateBookingAsync(BookingDto bookingDto); // Add this line

        Task<BookingDto?> GetBookingDetailsAsync(int bookingId);
        Task<IReadOnlyList<BookingDto>> GetAllBookingDetailsAsync();
        //Task<AdditionalItemDto?> AddAdditionalItemAsync(AdditionalItemDto additionalItemDto);
    }
}
