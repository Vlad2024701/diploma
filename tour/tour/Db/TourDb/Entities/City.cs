using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace diploma.Db.Tour.Entities
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        
        public virtual IList<Hotel>? Hotels { get; set; }
        [ForeignKey("Id")]
        public virtual Country? Country { get; set; }
        public City()
        {
            Hotels= new List<Hotel>();
        }
    }
}
