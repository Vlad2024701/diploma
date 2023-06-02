using diploma.Db.Tour.Entities;
using diploma.Db.Tour;
using tour.TourRepositories.IRepositories;
using tour.Models;
using tour.Db.TourDb.Entities;

namespace tour.TourRepositories.Repositories
{
    public class TourRepository : ITourRepository
    {
        private readonly TourContext tourContext;

        public TourRepository(TourContext tourContext)
        {
            this.tourContext = tourContext;
        }

        public List<Tour> GetAll()
        {
            try
            {
                var tours = tourContext.Tours
                    .Select(x => new Tour
                    {
                        Id = x.Id,
                        TourName = x.TourName,
                        TourDescription = x.TourDescription,
                        TourTimeStart = x.TourTimeStart,
                        TourTimeEnd = x.TourTimeEnd,
                        CountryId = x.CountryId,
                        Cost = x.Cost,
                        DepartureTime = x.DepartureTime,
                        CityId = x.CityId,
                        HotelId = x.HotelId,
                        Places = x.Places,
                        ImageURL = x.ImageURL
                    }).ToList();
                return tours;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error when trying to add new city\nMessage: {ex.Message}");
                return null;
            }
        }
        public List<Tour> GetPopular()
        {
            try
            {
                var tours = GetAll();
                var popularTours = tours.OrderBy(x=>x.Places.Count()).Take(4).ToList();
                return popularTours;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error when trying to add new city\nMessage: {ex.Message}");
                return null;
            }
        }

        public Tour AddTour(TourToAdd tourToAdd)
        {
            try
            {
                var tour = new Tour()
                {
                    ImageURL = tourToAdd.ImageURL,
                    TourName = tourToAdd.TourName,
                    TourDescription = tourToAdd.TourDescription,
                    TourTimeStart = tourToAdd.TourTimeStart,
                    TourTimeEnd = tourToAdd.TourTimeEnd,
                    DepartureTime = tourToAdd.DepartureTime,
                    Cost = tourToAdd.Cost,
                    CityId = tourToAdd.CityId,
                    CountryId = tourContext.Cities.Where(x => x.Id == tourToAdd.CityId).Select(x => x.CountryId).FirstOrDefault(),
                    HotelId = tourToAdd.HotelId
                };
                tourContext.Tours.Add(tour);
                tourContext.SaveChanges();

                var places = new List<Place>();
                var tourId = tourContext.Tours.Where(x=>x.TourName == tour.TourName).Select(x=>x.Id).FirstOrDefault();
                for (var i = 1; i <= tourToAdd.PlacesCount; i++)
                {
                    var place = new Place()
                    {
                        PlaceNumber = i,
                        TourId = tourId,
                        IsBooked = false
                    };
                    places.Add(place);
                }
                tourContext.Places.AddRange(places);
                tourContext.SaveChanges();
                return tour;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error when trying to add new city\nMessage: {ex.Message}");
                return null;
            }
        }
        public Tour? GetTourById(int id)
        {
            var tour = tourContext.Tours.Where(x => x.Id == id)
                .Select(x => new Tour
                {
                    Id = x.Id,
                    TourName = x.TourName,
                    TourDescription = x.TourDescription,
                    TourTimeStart = x.TourTimeStart,
                    TourTimeEnd = x.TourTimeEnd,
                    CountryId = x.CountryId,
                    Cost = x.Cost,
                    DepartureTime = x.DepartureTime,
                    CityId = x.CityId,
                    HotelId = x.HotelId,
                    Places = x.Places.Where(x => x.IsBooked == false).ToList(),
                    ImageURL = x.ImageURL
                }).FirstOrDefault();
            return tour;
        }
        public bool DeleteTour(int id)
        {
            var places = tourContext.Places.Where(x=>x.TourId == id).ToList();
            var tickets = tourContext.Ticket.Where(x => x.TourId == id).ToList();
            tourContext.Ticket.RemoveRange(tickets);
            tourContext.Places.RemoveRange(places);
            tourContext.SaveChanges();

            var tour = GetTourById(id);
            if (tour != null)
            {
                tourContext.Tours.Remove(tour);
                tourContext.SaveChanges();
                return true;
            }
            else
                return false;
        }
    }
}
