using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace diploma.Db.Tour.Entities
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NumberOfGuests { get; set; }
        public string? HotelBuilding { get; set; }
        public string? WindowView { get; set; }
        public int HotelId { get; set; }
        [ForeignKey("HotelId")]
        public virtual Hotel? Hotel { get; set; }
    }
}
