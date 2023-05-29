using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace diploma.Db.Tour.Entities
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        
        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        [JsonIgnore]
        public virtual Country? Country { get; set; }
        public virtual IList<Hotel>? Hotels { get; set; }
        public virtual IList<Tour>? Tours { get; set; }

        public City()
        {
            Tours= new List<Tour>();    
            Hotels= new List<Hotel>();
        }
    }
}
