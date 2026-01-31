using Meeting_Room_Booking_API.Data;
using Meeting_Room_Booking_API.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Meeting_Room_Booking_API.Controller
{
    [ApiController]
    [Route("api/Rooms")]
    public class RoomsController : ControllerBase
    {
        private readonly ApplicationDb _applicationDb;

        public RoomsController(ApplicationDb applicationDb)
        {
            _applicationDb = applicationDb;
        }

        [HttpGet]
        public async Task<IActionResult> GetRooms()
        {
            var rooms = _applicationDb.Rooms.ToList();
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoom(int id)
        {
            var room = await _applicationDb.Rooms.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            return Ok(room);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom([FromBody] Room room)
        {
            if(room.Name != null && room.Capacity != null)
            {
                return BadRequest("not null this Name and Capacity");
            }
            _applicationDb.Rooms.Add(room);
            await _applicationDb.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRoom), new { id = room.Id }, room);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRoom(int id, [FromBody] Room updatedRoom)
        {
            var room = await _applicationDb.Rooms.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            room.Name = updatedRoom.Name;
            room.Location = updatedRoom.Location;
            room.Capacity = updatedRoom.Capacity;
            await _applicationDb.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var room = await _applicationDb.Rooms.FindAsync(id);
            var hasFutureBookings = await _applicationDb.Bookings
            .AnyAsync(b => b.RoomId == id && b.StartTime.ToUniversalTime() > DateTime.UtcNow);
            if (hasFutureBookings)
                return BadRequest("Room has future bookings and cannot be deleted");
            if (room == null)
            {
                return NotFound();
            }
            _applicationDb.Rooms.Remove(room);
            await _applicationDb.SaveChangesAsync();
            return NoContent();
        }
    }
}
