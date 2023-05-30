using diploma.Db.Tour.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace tour.Db.TourDb.Entities
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        public int TourId { get; set; }
        [ForeignKey("TourId")]
        public virtual Tour? Tour { get; set; }
        public int PlaceId { get; set; }
        [ForeignKey("PlaceId")]
        public virtual Place? Place { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        [JsonIgnore]
        public virtual User? User { get; set; }
        public int RoomId { get; set; }
        [ForeignKey("RoomId")]
        [JsonIgnore]
        public virtual Room? Room { get; set; }
    }
}
