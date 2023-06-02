using diploma.Db.Tour.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using tour.Db.TourDb.Entities;

namespace tour.Models
{
    public class TourToAdd
    {
        public string? ImageURL { get; set; }
        public string? TourName { get; set; }
        public string? TourDescription { get; set; }
        public DateTime TourTimeStart { get; set; }
        public DateTime TourTimeEnd { get; set; }
        public string? DepartureTime { get; set; }
        public double Cost { get; set; }
        public int CityId { get; set; }
        public int HotelId { get; set; }
        public int PlacesCount { get; set; }
    }
}
