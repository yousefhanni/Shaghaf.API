using Microsoft.EntityFrameworkCore;
using Shaghaf.Core.Entities;
using Shaghaf.Core.Entities.BirthdayEntity;
using Shaghaf.Core.Entities.BookingEntities;
using Shaghaf.Core.Entities.HomeEntities;
using Shaghaf.Core.Entities.MembershipEntity;
using Shaghaf.Core.Entities.RoomEntities;
using System.Reflection;

namespace Shaghaf.Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Configure the enum to be stored as string
            // Configure the enum to be stored as string
            modelBuilder.Entity<Booking>()
                .Property(b => b.Status)
                .HasConversion(
                    v => v.ToString(),
                    v => (BookingStatus)Enum.Parse(typeof(BookingStatus), v)
                );

            // Configure the relationship between Cake and Birthday
            modelBuilder.Entity<Cake>()
                .HasOne(c => c.Birthday)
                .WithMany(b => b.Cakes)
                .HasForeignKey(c => c.BirthdayId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure the relationship between Decoration and Birthday
            modelBuilder.Entity<Decoration>()
                .HasOne(d => d.Birthday)
                .WithMany(b => b.Decorations)
                .HasForeignKey(d => d.BirthdayId)
                .OnDelete(DeleteBehavior.Cascade);

            // Remove the relationship configuration between PhotoSession and Birthday
            // Configure the relationship between PhotoSession and Room
            modelBuilder.Entity<PhotoSession>()
                .HasOne(p => p.Room)
                .WithMany(r => r.PhotoSessions)
                .HasForeignKey(p => p.RoomId);

            // Configure the relationship between Room and Birthday
            modelBuilder.Entity<Birthday>()
                .HasOne(b => b.Room)
                .WithMany(r => r.Birthdays)
                .HasForeignKey(b => b.RoomId);
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

        // Add new DbSets for MenuItem, CartItem, and Order

        public DbSet<MenuItem> MenuItems { get; set; }
    }
}
