using HotelRoomReservationApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelRoomReservationApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}
