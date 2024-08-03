using Shaghaf.Core.Entities;
using Shaghaf.Core.Entities.BookingEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaghaf.Core.Specifications.Booking_Spec
{
    public class BookWithAdditionalItemsSpecs : BaseSpecifications<Booking>
    {
        public BookWithAdditionalItemsSpecs() : base()
        {
           // Includes.Add(B => B.AdditionalItems);
        }
        public BookWithAdditionalItemsSpecs(int bookId) : base(B => B.Id == bookId)
        {
            //Includes.Add(B => B.AdditionalItems);
        }

    }
}
