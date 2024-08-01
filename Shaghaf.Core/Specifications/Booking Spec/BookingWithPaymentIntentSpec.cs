using Shaghaf.Core.Entities;
using Shaghaf.Core.Entities.BookingEntities;
using Shaghaf.Core.Specifications;

public class BookingWithPaymentIntentSpec : BaseSpecifications<Booking>
{
    public BookingWithPaymentIntentSpec(string paymentIntentId)
        : base(b => b.SessionId == paymentIntentId)
    {
    }
}
