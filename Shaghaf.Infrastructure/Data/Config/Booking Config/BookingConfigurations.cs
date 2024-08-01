using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shaghaf.Core.Entities;
using Shaghaf.Core.Entities.BookingEntities;
using Shaghaf.Core.Entities.RoomEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaghaf.Infrastructure.Data.Config.Booking_Config
{
    public class BookingConfigurations : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.Property(booking => booking.Status)
                            .HasConversion(
                            (BStatus) => BStatus.ToString(),
                            (BStatus) => (BookingStatus)Enum.Parse(typeof(BookingStatus), BStatus, true)

                            );


            builder.Property(booking => booking.Discount)
                .HasColumnType("decimal(12,2)");
            builder.Property(booking => booking.Amount)
                .HasColumnType("decimal(12,2)");
        }
    }
}
