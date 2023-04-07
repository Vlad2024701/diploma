using System.ComponentModel.DataAnnotations;

namespace diploma.Db.Tour.Entities
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual IList<City> Cities { get; set; }

        public Country()
        {
            Cities = new List<City>();
        }
    }
}
