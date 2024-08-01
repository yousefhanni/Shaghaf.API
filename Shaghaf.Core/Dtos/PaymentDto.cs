namespace Shaghaf.Core.Dtos
{
    public class PaymentDto
    {
        public int BookingId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string SuccessUrl { get; set; }
        public string CancelUrl { get; set; }
    }
}
