using diploma.Db.Tour.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace tour.Models
{
    public class HotelToAdd
    {
        public string? ImageURL { get; set; }
        public string? Name { get; set; }
        public int CityId { get; set; }
        public string? HotelDescription { get; set; }
    }
}
