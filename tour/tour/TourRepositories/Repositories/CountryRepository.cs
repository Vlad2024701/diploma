using diploma.Db.Tour.Entities;
using diploma.Db.Tour;
using tour.TourRepositories.IRepositories;
using tour.Models;
using System.Diagnostics.Metrics;
using tour.Db.TourDb.Entities;

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
                var cities = tourContext.Cities.Where(x => x.CountryId == id).ToList();
                if (cities.Any())
                {
                    foreach (var city in cities)
                    {
                        var hotels = tourContext.Hotels.Where(x => x.CityId == city.Id).ToList();
                        if (hotels.Any())
                        {
                            foreach (var hotel in hotels)
                            {
                                var rooms = tourContext.Rooms.Where(x => x.HotelId == hotel.Id).ToList();
                                if (rooms.Any())
                                {
                                    foreach (var room in rooms)
                                    {
                                        var tickets = tourContext.Ticket.Where(x => x.RoomId == room.Id).ToList();
                                        if (tickets.Any())
                                        {
                                            var placesToDelete = new List<Place>();
                                            foreach (var ticket in tickets)
                                            {
                                                var places = tourContext.Places.Where(x => x.Id == ticket.PlaceId).ToList();
                                                placesToDelete.AddRange(places);
                                            }
                                            tourContext.Ticket.RemoveRange(tickets);
                                            tourContext.SaveChanges();
                                            tourContext.Places.RemoveRange(placesToDelete);
                                            tourContext.SaveChanges();
                                        }
                                    }
                                    tourContext.Rooms.RemoveRange(rooms);
                                    tourContext.SaveChanges();
                                }
                                var toursFKHotel = tourContext.Tours.Where(x=> x.HotelId == hotel.Id).ToList();
                                tourContext.Tours.RemoveRange(toursFKHotel);
                                tourContext.SaveChanges();
                            }
                        }

                    }
                    tourContext.Cities.RemoveRange(cities);
                }
                tourContext.Countries.Remove(country);
                tourContext.SaveChanges();
                return true;
            }
            else
                return false;
        }
    }
}
