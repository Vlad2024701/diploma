using diploma.Db.Tour.Entities;

namespace tour.TourRepositories.IRepositories
{
    public interface ICountryRepository
    {
        List<Country> GetAll();
        Country AddCountry(Country country);
        bool DeleteCountry(int id);
        Country GetCountryById(int id);
    }
}
