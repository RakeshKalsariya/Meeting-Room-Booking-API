using Meeting_Room_Booking_API.Domain;
using Microsoft.EntityFrameworkCore;

namespace Meeting_Room_Booking_API.Data
{
    public class ApplicationDb : DbContext
    {
        public ApplicationDb(DbContextOptions<ApplicationDb> options) : base(options)
        {
        }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
