﻿using Shaghaf.Core.Entities.BookingEntities;
using Shaghaf.Core.Repositories.Contract;
using Shaghaf.Core.Services.Contract;
using AutoMapper;
using Shaghaf.Core.Dtos;
using Shaghaf.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shaghaf.Core.Specifications.Booking_Spec;
using Shaghaf.Core.Dtos.BookingDtos;
using Shaghaf.Core.Dtos.PaymentDtos;

namespace Shaghaf.Service.Services.Implementation
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPaymentService _paymentService;

        public BookingService(IBookingRepository bookingRepository, IUnitOfWork unitOfWork, IMapper mapper, IPaymentService paymentService)
        {
            _bookingRepository = bookingRepository;
            _unitOfWork = unitOfWork;           
            _mapper = mapper;
            _paymentService = paymentService;
        }

    public async Task<BookingDto> CreateBookingAsync(BookingToCreateDto bookingToCreateDto)
{
    var booking = _mapper.Map<Booking>(bookingToCreateDto);

    // Save the booking first to ensure it has a valid ID
    await _unitOfWork.Repository<Booking>().AddAsync(booking);
    await _unitOfWork.CompleteAsync(); // Save to get BookingId

    // Now create the payment session
    var paymentSession = await _paymentService.CreateBookingCheckoutSession(new PaymentDto
    {
        Amount = booking.Amount,
        Currency = booking.Currency,
        SuccessUrl = "https://localhost:7095/success",
        CancelUrl = "https://localhost:7095/cancel",
        BookingId = booking.Id // Now we have a valid BookingId
    });

    booking.PaymentStatus = false;

    // Save the booking again with updated payment info
    _unitOfWork.Repository<Booking>().Update(booking);
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

            booking = _mapper.Map(bookingDto, booking);

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

        public async Task<bool> CheckBookingPaymentStatusAsync(int bookingId)
        {
            var booking = await _unitOfWork.Repository<Booking>().GetByIdAsync(bookingId);
            if (booking == null) return false;

            var paymentStatus = await _paymentService.CheckPaymentStatusAsync(booking.PaymentIntentId);

            if (paymentStatus.PaymentStatus)
            {
                booking.PaymentStatus = true;
                booking.Status = BookingStatus.Confirmed;
                _bookingRepository.Update(booking);
                await _unitOfWork.CompleteAsync();
            }

            return booking.PaymentStatus;
        }

        public async Task<bool> UpdatePaymentIntentAsync(int id, string paymentIntentId)
        {
            var booking = await _unitOfWork.Repository<Booking>().GetByIdAsync(id);
            if (booking == null)
            {
                throw new KeyNotFoundException("Booking not found.");
            }

            booking.PaymentIntentId = paymentIntentId;
            _bookingRepository.Update(booking);
            await _unitOfWork.CompleteAsync();
            return true;
        }
        public async Task DeleteBookingAsync(int bookingId)
        {
            var booking = await _unitOfWork.Repository<Booking>().GetByIdAsync(bookingId);
            if (booking == null)
            {
                throw new KeyNotFoundException("Booking not found.");
            }

            _unitOfWork.Repository<Booking>().Delete(booking);
            await _unitOfWork.CompleteAsync();
        }

    }
}
