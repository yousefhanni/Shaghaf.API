using Stripe;
using Shaghaf.Core.Dtos;
using Shaghaf.Core.Entities;
using Shaghaf.Core.Services.Contract;
using Microsoft.Extensions.Options;
using AutoMapper;
using Shaghaf.Core.Entities.BookingEntities;
using Stripe.Checkout;
using Shaghaf.API.Helpers;
using Shaghaf.Core;

namespace Shaghaf.Application.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly StripeSettings _stripeSettings;

        // Constructor to initialize dependencies and set Stripe API key
        public PaymentService(IUnitOfWork unitOfWork, IMapper mapper, IOptions<StripeSettings> stripeSettings)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _stripeSettings = stripeSettings.Value;
            StripeConfiguration.ApiKey = _stripeSettings.SecretKey;
        }

        // Create a Stripe checkout session asynchronously
        public async Task<Session> CreateCheckoutSession(PaymentDto paymentDto)
        {
            var booking = await _unitOfWork.Repository<Booking>().GetByIdAsync(paymentDto.BookingId);
            if (booking == null) throw new KeyNotFoundException("Booking not found");

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmountDecimal = paymentDto.Amount * 100,
                            Currency = paymentDto.Currency,
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = "Booking Payment"
                            },
                        },
                        Quantity = 1,
                    }
                },
                Mode = "payment",
                SuccessUrl = paymentDto.SuccessUrl,
                CancelUrl = paymentDto.CancelUrl,
                Metadata = new Dictionary<string, string>
                {
                    { "BookingId", booking.Id.ToString() }
                }
            };

            var service = new SessionService();
            Session session = await service.CreateAsync(options);

            booking.SessionId = session.Id;
            booking.Status = BookingStatus.Pending;
            await _unitOfWork.CompleteAsync();

            return session;
        }

        // Handle Stripe events for payment status updates asynchronously
        public async Task HandleStripeEvent(string json, string stripeSignature, string webhookSecret)
        {
            var stripeEvent = EventUtility.ConstructEvent(json, stripeSignature, webhookSecret);

            if (stripeEvent.Type == Events.CheckoutSessionCompleted)
            {
                var session = stripeEvent.Data.Object as Session;
                var booking = await _unitOfWork.Repository<Booking>().GetByIdAsync(int.Parse(session.Metadata["BookingId"]));
                if (booking != null)
                {
                    booking.Status = BookingStatus.Confirmed;
                    await _unitOfWork.CompleteAsync();
                }
            }
        }

        // Update payment intent status asynchronously
        public async Task<Booking> UpdatePaymentIntentToSucceedOrFail(string paymentIntentId, bool succeeded)
        {
            var spec = new BookingWithPaymentIntentSpec(paymentIntentId);
            var booking = await _unitOfWork.Repository<Booking>().GetEntityWithSpecAsync(spec);

            if (booking != null)
            {
                booking.Status = succeeded ? BookingStatus.Confirmed : BookingStatus.Failed;
                _unitOfWork.Repository<Booking>().Update(booking);
                await _unitOfWork.CompleteAsync();
            }

            return booking;
        }

       /// Polling Service instead of Webhook :
       /// This service periodically checks the payment status of a booking by querying the payment provider's API.
       /// It retrieves the booking details from the database, uses the session ID to fetch the payment status from the SessionService,
       /// and updates the booking status in the database based on the payment status. This approach is used as an alternative
       /// to real-time notifications (webhooks) from the payment provider, providing a way to manually or periodically confirm payment status.
        public async Task<string> CheckPaymentStatusAsync(int bookingId)
        {
            // Retrieve the booking details using the booking ID
            var booking = await _unitOfWork.Repository<Booking>().GetByIdAsync(bookingId);
            if (booking == null) throw new KeyNotFoundException("Booking not found");

            // Ensure the booking has a session ID
            if (string.IsNullOrEmpty(booking.SessionId)) throw new InvalidOperationException("Session ID not found for the booking");

            // Create a session service to interact with the session API
            var service = new SessionService();
            var session = await service.GetAsync(booking.SessionId);

            // Check the payment status of the session and update the booking status accordingly
            switch (session.PaymentStatus)
            {
                case "paid":
                    booking.Status = BookingStatus.Confirmed;
                    break;
                case "unpaid":
                case "no_payment_required":
                    booking.Status = BookingStatus.Failed;
                    break;
            }

            // Save changes to the booking status
            await _unitOfWork.CompleteAsync();
            return booking.Status.ToString();
        }

    }
}
