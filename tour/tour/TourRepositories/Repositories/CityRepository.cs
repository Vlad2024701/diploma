using diploma.Db.Tour;
using diploma.Db.Tour.Entities;
using tour.TourRepositories.IRepositories;

namespace tour.TourRepositories.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly TourContext tourContext;

        public CityRepository(TourContext tourContext) 
        {
            this.tourContext = tourContext;
        }

        public List<City> GetAll() 
        {
            var cities = tourContext.Cities
                .Select(x => new City
                {
                    Id = x.Id,
                    Name = x.Name,
                    CountryId = x.CountryId,
                    Hotels = x.Hotels
                }).ToList();
            return cities;
        }

        public City AddCity(City city)
        {
            try
            {
                tourContext.Cities.Add(city);
                tourContext.SaveChanges();
                return city;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error when trying to add new city\nMessage: {ex.Message}");
                return city;
            }
        }
        public City GetCityById(int id)
        {
            var city = tourContext.Cities.Where(x => x.Id == id)
                .Select(x => new City
                {
                    Id = x.Id,
                    Name = x.Name,
                    CountryId = x.CountryId
                }).FirstOrDefault();
            return city;
        }
        public bool DeleteCity(int id)
        {
            var city = GetCityById(id);
            if (city != null)
            {
                tourContext.Cities.Remove(city);
                tourContext.SaveChanges();
                return true;
            }
            else
                return false;
        }
    }
}
