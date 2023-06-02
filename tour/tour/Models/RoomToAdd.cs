using diploma.Db.Tour.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using tour.Db.TourDb.Entities;

namespace tour.Models
{
    public class RoomToAdd
    {
        public string? ImageURL { get; set; }
        public string? Name { get; set; }
        public int NumberOfGuests { get; set; }
        public string? HotelBuilding { get; set; }
        public string? WindowView { get; set; }
        public int HotelId { get; set; }
    }
}
