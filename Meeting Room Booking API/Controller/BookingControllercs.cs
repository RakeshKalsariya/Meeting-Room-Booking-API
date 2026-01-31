using Meeting_Room_Booking_API.Data;
using Meeting_Room_Booking_API.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Meeting_Room_Booking_API.Controller
{
    [ApiController]
    [Route("api/Booking")]
    public class BookingControllercs : ControllerBase
    {
        private readonly ApplicationDb _applicationDb;

        public BookingControllercs(ApplicationDb applicationDb)
        {
            _applicationDb = applicationDb;
        }

        [HttpGet("room/{roomId:int}")]
        public async Task<IActionResult> GetBookings(int roomId)
        {
            var bookings = await _applicationDb.Bookings
                .Include(b => b.Room)
                .Where(b => b.RoomId == roomId)
                .ToListAsync();
            return Ok(bookings);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBooking(int id)
        {
            var booking = await _applicationDb.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            return Ok(booking);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] Booking booking)
        {

            if (booking.StartTime.ToUniversalTime() >= booking.EndTime)
                return BadRequest("StartTime must be before EndTime");


            if (booking.StartTime.ToUniversalTime() > DateTime.UtcNow)
                return BadRequest("Cannot book in the past");

            var bookings = await _applicationDb.Bookings.FindAsync(booking.RoomId);

            if (bookings != null && bookings.StartTime < booking.EndTime && bookings.EndTime > booking.StartTime)
            {
                return BadRequest("Invalid RoomId");
            }
            await _applicationDb.Bookings.AddAsync(booking);
            await _applicationDb.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBooking), new { id = booking.Id }, booking);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> CancelBooking(int id)
        {
            var booking = await _applicationDb.Bookings.FindAsync(id);
            if (booking == null) return NotFound();
             _applicationDb.Bookings.Remove(booking);
            await _applicationDb.SaveChangesAsync();
            return NoContent();
        }

    }
}
