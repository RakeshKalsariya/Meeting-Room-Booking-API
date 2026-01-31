using System.ComponentModel.DataAnnotations.Schema;

namespace Meeting_Room_Booking_API.Domain
{
    public class Booking
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public Room? Room { get; set; }
    }
}
