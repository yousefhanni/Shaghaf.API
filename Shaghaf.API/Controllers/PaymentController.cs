using Microsoft.AspNetCore.Mvc;
using Shaghaf.Core.Dtos;
using Shaghaf.Core.Services.Contract;
using Microsoft.Extensions.Logging;
using Talabat.APIs.Controllers;

namespace Shaghaf.API.Controllers
{
    public class PaymentController : BaseApiController
    {
        private readonly IPaymentService _paymentService;
        private readonly ILogger<PaymentController> _logger;

        public PaymentController(IPaymentService paymentService, ILogger<PaymentController> logger)
        {
            _paymentService = paymentService;
            _logger = logger;
        }

        [HttpGet("check-payment-status/{paymentIntentId}")]
        public async Task<ActionResult<PaymentStatusDto>> CheckPaymentStatus(string paymentIntentId)
        {
            try
            {
                var paymentStatus = await _paymentService.CheckPaymentStatusAsync(paymentIntentId);

                if (paymentStatus == null)
                {
                    return NotFound(new { Message = "Payment status not found" });
                }

                return Ok(paymentStatus);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while checking the payment status: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
