using diploma.Db.Tour.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace tour.Db.TourDb.Entities
{
    public class Place
    {
        public int Id { get; set; }
        public int PlaceNumber { get; set; }
        public int TourId { get; set; }
        [ForeignKey("Id")]
        public virtual Tour? Tour { get; set; }

        public bool IsBooked { get; set; }
        
        [ForeignKey("Id")]
        public User? User { get; set; }
    }
}
