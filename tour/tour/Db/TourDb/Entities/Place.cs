using diploma.Db.Tour.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace tour.Db.TourDb.Entities
{
    public class Place
    {
        public int Id { get; set; }
        public int PlaceNumber { get; set; }
        public int TourId { get; set; }
        [ForeignKey("TourId")]
        [JsonIgnore]
        public virtual Tour? Tour { get; set; }
        public bool IsBooked { get; set; }
        [AllowNull]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        [JsonIgnore]
        public User? User { get; set; }

        public virtual IList<Ticket> Tickets { get; set; }
        public Place()
        {
            Tickets = new List<Ticket>();
        }
    }
}
