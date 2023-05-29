using System.ComponentModel.DataAnnotations;

namespace diploma.Db.Tour.Entities
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual IList<City> Cities { get; set; }
        public virtual IList<Tour> Tours { get; set; }
        public Country()
        {
            Tours = new List<Tour>();
            Cities = new List<City>();
        }
    }
}
