using diploma.Db.Tour.Entities;
using diploma.Db.Tour;
using tour.TourRepositories.IRepositories;

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
                        Places = x.Places
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

        public Tour AddTour(Tour tour)
        {
            try
            {
                tourContext.Tours.Add(tour);
                tourContext.SaveChanges();
                return tour;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error when trying to add new city\nMessage: {ex.Message}");
                return tour;
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
                    Places = x.Places.Where(x => x.IsBooked == false).ToList()
                }).FirstOrDefault();
            return tour;
        }
        public bool DeleteTour(int id)
        {
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
