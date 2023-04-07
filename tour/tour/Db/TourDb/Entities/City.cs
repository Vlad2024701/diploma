using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace diploma.Db.Tour.Entities
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        
        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public virtual Country? Country { get; set; }
        public virtual IList<Hotel>? Hotels { get; set; }
        public City()
        {
            Hotels= new List<Hotel>();
        }
    }
}
