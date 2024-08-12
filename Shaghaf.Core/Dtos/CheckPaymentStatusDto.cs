namespace Shaghaf.Core.Dtos
{
    public class CheckPaymentStatusDto
    {
        public int OrderId { get; set; }
        public string PaymentIntentId { get; set; } // Add PaymentIntentId
    }
}
