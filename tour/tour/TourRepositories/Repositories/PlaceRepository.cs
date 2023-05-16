using diploma.Db.Tour.Entities;
using diploma.Db.Tour;
using tour.TourRepositories.IRepositories;
using tour.Db.TourDb.Entities;

namespace tour.TourRepositories.Repositories
{
    public class PlaceRepository : IPlaceRepository
    {
        private readonly TourContext tourContext;

        public PlaceRepository(TourContext tourContext)
        {
            this.tourContext = tourContext;
        }
        public List<Place> GetAll()
        {
            var places = tourContext.Places
                .Select(x => new Place
                {
                    Id = x.Id,
                    PlaceNumber = x.PlaceNumber,
                    TourId = x.TourId,
                    UserLogin = x.UserLogin,
                    IsBooked = x.IsBooked
                }).ToList();
            return places;
        }

        public Place AddPlace(Place place)
        {
            try
            {
                tourContext.Places.Add(place);
                tourContext.SaveChanges();
                return place;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error when trying to add new hotel\nMessage: {ex.Message}");
                return place;
            }
        }

        public Place GetPlaceById(int id)
        {
            var place = tourContext.Places.FirstOrDefault(x => x.Id == id);
            return place;
        }

        public List<IList<Place>> GetPlacesByTourId(int tourId)
        {
            var places = tourContext.Tours.Where(x => x.Id == tourId)
                .Select(x => x.Places).ToList();
            return places;
        }
        public bool DeletePlace(int id)
        {
            var place = GetPlaceById(id);
            if (place != null)
            {
                tourContext.Places.Remove(place);
                tourContext.SaveChanges();
                return true;
            }
            else
                return false;
        }
    }
}
