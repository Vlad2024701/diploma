using diploma.Db.Tour.Entities;

namespace tour.TourRepositories.IRepositories
{
    public interface ICityRepository
    {
        List<City> GetAll();
        City AddCity(City city);
        bool DeleteCity(int id);
        City GetCityById(int id);
    }
}
