using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public virtual Country? Country { get; set;}
        //public int CityId { get; set; }
        //[ForeignKey("CityId")]
        //public virtual City? City { get; set; }
        //public int HotelId { get; set; }
        //[ForeignKey("HotelId")]
        //public virtual Hotel? Hotel { get; set; }
        //public int RoomId { get; set; }
        //[ForeignKey("RoomId")]
        //public virtual Room? Room { get; set; }
        public virtual IList<Place> Places { get; set; }

        public Tour ()
        {
            Places = new List<Place> ();
        }
    }
}
