using diploma.Db.Tour.Entities;
using diploma.Db.Tour;
using tour.TourRepositories.IRepositories;
using tour.Models;
using System.Diagnostics.Metrics;

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
                return null;
            }
        }

        public CountryWithCity AddCountryWithCity(CountryWithCity countryWithCity)
        {
            try
            {
                var country = tourContext.Countries
                    .Where(x => x.Name.ToUpper() == countryWithCity.CountryName.ToUpper().Trim()).FirstOrDefault();
                if (country == null)
                {
                    var newCountry = new Country() { Name = countryWithCity.CountryName };
                    tourContext.Countries.Add(newCountry);
                    tourContext.SaveChanges();
                    var newCountryId = tourContext.Countries
                        .Where(x => x.Name == countryWithCity.CountryName).FirstOrDefault();
                    var newCity = new City() { Name = countryWithCity.CityName, CountryId = newCountryId.Id };
                    tourContext.Cities.Add(newCity);
                    tourContext.SaveChanges();
                }
                else
                {
                    var checkCity = tourContext.Cities
                        .Where(x => x.Name.ToUpper() == countryWithCity.CityName.ToUpper().Trim()).FirstOrDefault();
                    if (checkCity != null)
                        return null;
                    var newCity = new City() { Name = countryWithCity.CityName, CountryId = country.Id };
                    tourContext.Cities.Add(newCity);
                    tourContext.SaveChanges();
                }
                return countryWithCity;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error when trying to add new city\nMessage: {ex.Message}");
                return null;
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
