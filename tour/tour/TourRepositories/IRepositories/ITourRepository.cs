using diploma.Db.Tour.Entities;

namespace tour.TourRepositories.IRepositories
{
    public interface ITourRepository
    {
        public List<Tour> GetAll();
        public Tour AddTour(Tour tour);
        public Tour? GetTourById(int id);
        public bool DeleteTour(int id);
        public List<Tour> GetPopular();
    }
}
