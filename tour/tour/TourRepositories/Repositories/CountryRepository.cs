using diploma.Db.Tour.Entities;
using diploma.Db.Tour;
using tour.TourRepositories.IRepositories;

namespace tour.TourRepositories.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly TourContext tourContext;

        public CountryRepository(TourContext tourContext)
        {
            this.tourContext = tourContext;
        }

        public List<Country> GetAll()
        {
            var countries = tourContext.Countries
                .Select(x => new Country
                {
                    Id = x.Id,
                    Name = x.Name,
                    Cities = x.Cities,
                }).ToList();
            return countries;
        }

        public Country AddCountry(Country country)
        {
            try
            {
                tourContext.Countries.Add(country);
                tourContext.SaveChanges();
                return country;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error when trying to add new city\nMessage: {ex.Message}");
                return country;
            }
        }

        public Country GetCountryById(int id)
        {
            var country = tourContext.Countries.Where(x => x.Id == id)
                .Select(x => new Country
                {
                    Id = x.Id,
                    Name = x.Name
                }).FirstOrDefault();
            return country;
        }
        public bool DeleteCountry(int id)
        {
            var country = GetCountryById(id);
            if (country != null)
            {
                tourContext.Countries.Remove(country);
                tourContext.SaveChanges();
                return true;
            }
            else
                return false;
        }
    }
}
