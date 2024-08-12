namespace Shaghaf.Core.Dtos
{
    public class PaymentSessionDto
    {
        public string PaymentIntentId { get; set; } = null!; // Payment Intent ID
        public string SessionId { get; set; } = null!; // Session ID for the payment session
    }
}
