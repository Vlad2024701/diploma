using diploma.Db.Tour.Entities;
using tour.Models;

namespace tour.TourRepositories.IRepositories
{
    public interface ICountryRepository
    {
        public List<Country> GetAll();
        public Country AddCountry(Country country);
        public bool DeleteCountry(int id);
        public Country GetCountryById(int id);
        public CountryWithCity AddCountryWithCity(CountryWithCity countryWithCity);
    }
}
