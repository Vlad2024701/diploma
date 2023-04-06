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
                    Hotels  = x.Hotels
                    
                }).ToList();
            return cities;
        }
    }
}
