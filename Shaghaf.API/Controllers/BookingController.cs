﻿using Microsoft.AspNetCore.Mvc;
using Shaghaf.Core.Dtos;
using Shaghaf.Core.Services.Contract;

namespace Shaghaf.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IPaymentService _paymentService;
        private readonly ILogger<BookingController> _logger;

        public BookingController(IBookingService bookingService, IPaymentService paymentService, ILogger<BookingController> logger)
        {
            _bookingService = bookingService;
            _paymentService = paymentService;
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] BookingToCreateDto bookingToCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _bookingService.CreateBookingAsync(bookingToCreateDto);

            if (result == null)
                return BadRequest(new { error = "Booking creation failed." });

            var paymentSession = await _paymentService.CreateBookingCheckoutSession(
                new PaymentDto
                {
                    Amount = result.Amount,
                    Currency = bookingToCreateDto.Currency,
                    SuccessUrl = "https://localhost:7095/success",
                    CancelUrl = "https://localhost:7095/cancel",
                    BookingId = result.Id
                }
            );

            if (paymentSession == null)
            {
                return BadRequest(new { error = "Payment session creation failed." });
            }

            // Update the BookingToCreateDto with payment session information
            result.PaymentIntentId = paymentSession.Id;
            result.SessionId = paymentSession.Id;
            result.PaymentStatus = false; // Assuming payment is not yet completed

            return Ok(result);
        }


        [HttpPut("{bookingId}")]
        public async Task<IActionResult> UpdateBooking(int bookingId, [FromBody] BookingDto bookingDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bookingDto.Id = bookingId;
            await _bookingService.UpdateBookingAsync(bookingDto);
            return NoContent();
        }

        [HttpPost("create-payment")]
        public async Task<IActionResult> CreatePayment([FromBody] PaymentDto paymentDto)
        {
            try
            {
                var paymentSession = await _paymentService.CreateBookingCheckoutSession(paymentDto);
                return Ok(new { url = paymentSession.Url });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("update-payment-intent")]
        public async Task<IActionResult> UpdatePaymentIntent([FromBody] UpdatePaymentIntentDto updatePaymentIntentDto)
        {
            var updated = await _bookingService.UpdatePaymentIntentAsync(updatePaymentIntentDto.Id, updatePaymentIntentDto.PaymentIntentId);
            if (!updated)
                return NotFound("Booking not found");

            return Ok("Payment intent updated successfully");
        }

        [HttpGet("check-payment-status/{bookingId}")]
        public async Task<IActionResult> CheckBookingPaymentStatus(int bookingId)
        {
            var isPaymentConfirmed = await _bookingService.CheckBookingPaymentStatusAsync(bookingId);

            if (!isPaymentConfirmed)
            {
                return BadRequest(new { error = "Payment not confirmed or booking not found." });
            }

            return Ok(new { success = "Payment confirmed for the booking." });
        }
    }
}
