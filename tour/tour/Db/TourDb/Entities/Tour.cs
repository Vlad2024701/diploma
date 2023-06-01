using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using tour.Db.TourDb.Entities;

namespace diploma.Db.Tour.Entities
{
    public class Tour
    {
        [Key]
        public int Id { get; set; }
        public string? TourName { get; set; }
        public string? TourDescription { get; set; }
        public DateTime TourTimeStart { get; set; }
        public DateTime TourTimeEnd { get; set; }
        public string? DepartureTime { get; set; }
        public double Cost { get; set; }
        [Required]
        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        [JsonIgnore]
        public virtual Country? Country { get; set;}
        [Required]
        public int CityId { get; set; }
        [ForeignKey("CityId")]
        [JsonIgnore]
        public virtual City? City { get; set; }
        [Required]
        public int HotelId { get; set; }
        [ForeignKey("HotelId")]
        [JsonIgnore]
        public virtual Hotel? Hotel { get; set; }
        public virtual IList<Place> Places { get; set; }
        public Tour()
        {
            Places = new List<Place> ();
        }
    }
}
