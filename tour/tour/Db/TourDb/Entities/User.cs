using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using tour.Db.TourDb.Entities;

namespace diploma.Db.Tour.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
        [JsonIgnore]
        public virtual IList<Ticket> Tickets { get; set; }
        public User() { 
            Tickets = new List<Ticket>();
        }
    }
}
