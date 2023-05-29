using diploma.Db.Tour.Entities;
using System.ComponentModel.DataAnnotations;

namespace tour.Models
{
    public class CountryWithCity
    {
        public string? CountryName { get; set; }
        public string? CityName { get; set; }
    }
}
