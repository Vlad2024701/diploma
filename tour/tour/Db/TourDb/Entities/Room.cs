using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace diploma.Db.Tour.Entities
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? NumberOfGuests { get; set; }
        [Required]
        public string? HotelBuilding { get; set; }
        [Required]
        public string? WindowView { get; set; }

        [ForeignKey("Id")]
        public virtual Hotel? Hotel { get; set; }
    }
}
