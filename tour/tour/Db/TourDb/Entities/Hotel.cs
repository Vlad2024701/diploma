using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace diploma.Db.Tour.Entities
{
    public class Hotel
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int CityId { get; set; }
        [ForeignKey("CityId")]
        [JsonIgnore]
        public virtual City? City { get; set; }
        public virtual IList<Room> Rooms {get; set;}
        [JsonIgnore]
        public virtual IList<Tour> Tours { get; set;}
        public Hotel() 
        {
            Tours = new List<Tour>();
            Rooms = new List<Room>();
        }  
    }
}
