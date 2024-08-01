using Shaghaf.Core.Entities;
using Shaghaf.Core.Entities.BookingEntities;
using Shaghaf.Core.Specifications;
using System;
using System.Linq.Expressions;

namespace Shaghaf.Core.Specifications.BookingSpecs
{
    public class BookingWithSessionSpecification : BaseSpecifications<Booking>
    {
        public BookingWithSessionSpecification(string sessionId)
            : base(b => b.SessionId == sessionId)
        {
            // إضافة الكيانات المرتبطة
           
        }
    }
}
