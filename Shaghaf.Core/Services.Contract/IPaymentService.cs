using Shaghaf.Core.Dtos;
using Shaghaf.Core.Entities;
using Stripe.Checkout;
using System.Threading.Tasks;

namespace Shaghaf.Core.Services.Contract
{
    public interface IPaymentService
    {
        Task<Session> CreateCheckoutSession(PaymentDto paymentDto);
        Task HandleStripeEvent(string json, string stripeSignature, string webhookSecret);
        Task<Booking> UpdatePaymentIntentToSucceedOrFail(string paymentIntentId, bool succeeded);
        Task<string> CheckPaymentStatusAsync(int bookingId);  // Add this method
    }
}
