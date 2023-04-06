using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace diploma.Db.Tour.Entities
{
    public class Hotel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Nam { get; set; }

        public virtual IList<Room>? Rooms {get; set;}
        [ForeignKey("Id")]
        public virtual City? City { get; set; }
        public Hotel() 
        {
            Rooms = new List<Room>();
        }  
    }
}
