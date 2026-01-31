using System.ComponentModel.DataAnnotations;

namespace Meeting_Room_Booking_API.Domain
{
    public class Room 
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string Location { get; set; }
    }
}
