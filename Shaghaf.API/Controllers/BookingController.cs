using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shaghaf.Core.Dtos;
using Shaghaf.Core.Services.Contract;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class BookingController : ControllerBase
{
    private readonly IBookingService _bookingService;
    private readonly IPaymentService _paymentService;

    public BookingController(IBookingService bookingService, IPaymentService paymentService)
    {
        _bookingService = bookingService ?? throw new ArgumentNullException(nameof(bookingService));
        _paymentService = paymentService ?? throw new ArgumentNullException(nameof(paymentService));
    }

    [HttpPost]
    public async Task<IActionResult> CreateBooking([FromBody] BookingToCreateDto bookingToCreateDto)
    {
        var result = await _bookingService.CreateBookingAsync(bookingToCreateDto);
        return Ok(result);
    }

    [HttpPut("{bookingId}")]
    public async Task<IActionResult> UpdateBooking(int bookingId, [FromBody] BookingDto bookingDto)
    {
        bookingDto.Id = bookingId;
        await _bookingService.UpdateBookingAsync(bookingDto);
        return NoContent();
    }

    [HttpGet("{bookingId}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<BookingDto>> GetBookingDetails(int bookingId)
    {
        var result = await _bookingService.GetBookingDetailsAsync(bookingId);
        if (result == null)
            return NotFound("Booking Not Found !!");
        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<BookingDto>>> GetAllBookingDetails()
    {
        var result = await _bookingService.GetAllBookingDetailsAsync();
        if (result == null || result.Count == 0)
            return NotFound("No Bookings Found !!");
        return Ok(result);
    }

    [HttpPost("payment")]
    public async Task<IActionResult> CreatePayment([FromBody] PaymentDto paymentDto)
    {
        try
        {
            var session = await _paymentService.CreateCheckoutSession(paymentDto);
            return Ok(new { url = session.Url });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("payment/check-status/{bookingId}")]
    public async Task<IActionResult> GetPaymentStatus(int bookingId)
    {
        try
        {
            var status = await _paymentService.CheckPaymentStatusAsync(bookingId);
            return Ok(new { status });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
