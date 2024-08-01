using Microsoft.EntityFrameworkCore;
using Shaghaf.Core.Entities;
using Shaghaf.Core.Entities.BookingEntities;
using Shaghaf.Core.Entities.HomeEntities;
using Shaghaf.Core.Entities.RoomEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Shaghaf.Infrastructure.Data
{
    public class StoreContext : DbContext
    {

        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Home> Homes { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Birthday> Birthdays { get; set; }
        public DbSet<Cake> Cakes { get; set; }
        public DbSet<Decoration> Decorations { get; set; }
        public DbSet<PhotoSession> PhotoSessions { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
      //  public DbSet<AdditionalItem> AdditionalItems { get; set; }
    }
}
