using AutoMapper;
using Shaghaf.Core.Dtos;
using Shaghaf.Core.Entities.BookingEntities;
using Shaghaf.Core.Repositories.Contract;
using Shaghaf.Core.Services.Contract;
using Shaghaf.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shaghaf.Core.Specifications.Booking_Spec;

public class BookingService : IBookingService
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BookingService(IBookingRepository bookingRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _bookingRepository = bookingRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BookingDto> CreateBookingAsync(BookingToCreateDto bookingToCreateDto)
    {
        var booking = _mapper.Map<Booking>(bookingToCreateDto);
        _unitOfWork.Repository<Booking>().Add(booking);
        await _unitOfWork.CompleteAsync();
        return _mapper.Map<BookingDto>(booking);
    }

    public async Task UpdateBookingAsync(BookingDto bookingDto)
    {
        var booking = await _bookingRepository.FindUniqueBookingAsync(
            bookingDto.RoomId, bookingDto.StartDate, bookingDto.EndDate, bookingDto.CustomerName);

        if (booking == null)
        {
            throw new KeyNotFoundException("No booking found matching the specified criteria.");
        }

        if (Enum.TryParse<BookingStatus>(bookingDto.Status.ToString(), out var status))
        {
            booking.Status = status;
        }
        else
        {
            throw new ArgumentException("Invalid status value");
        }

        _bookingRepository.Update(booking);
        await _unitOfWork.CompleteAsync();
    }

    public async Task<BookingDto?> GetBookingDetailsAsync(int bookingId)
    {
        var spec = new BookWithAdditionalItemsSpecs(bookingId);
        var booking = await _unitOfWork.Repository<Booking>().GetByIdWithSpecAsync(spec);
        return booking == null ? null : _mapper.Map<BookingDto>(booking);
    }

    public async Task<IReadOnlyList<BookingDto>> GetAllBookingDetailsAsync()
    {
        var spec = new BookWithAdditionalItemsSpecs();
        var bookings = await _unitOfWork.Repository<Booking>().GetAllWithSpecAsync(spec);
        return _mapper.Map<IReadOnlyList<BookingDto>>(bookings);
    }
}
