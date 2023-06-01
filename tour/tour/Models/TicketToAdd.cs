using diploma.Db.Tour.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using tour.Db.TourDb.Entities;

namespace tour.Models
{
    public class TicketToAdd
    {
        public int TourId { get; set; }
        public int PlacesCount { get; set; }
        public int UserId { get; set; } 
        public int RoomId { get; set; }
    }
}
