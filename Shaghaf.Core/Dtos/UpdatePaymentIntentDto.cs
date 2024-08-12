namespace Shaghaf.Core.Dtos
{
    public class UpdatePaymentIntentDto
    {
        public int Id { get; set; } // Can be BookingId or OrderId
        public string PaymentIntentId { get; set; } = null!;
    }
}
