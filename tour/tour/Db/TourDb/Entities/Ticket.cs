using diploma.Db.Tour.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tour.Db.TourDb.Entities
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        public int TourId { get; set; }
        [ForeignKey("TourId")]
        public virtual Tour? Country { get; set; }
        public int PlaceId { get; set; }
        [ForeignKey("PlaceId")]
        public virtual Place? Place { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User? User { get; set; }
    }
}
