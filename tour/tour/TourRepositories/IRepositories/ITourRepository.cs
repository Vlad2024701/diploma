using diploma.Db.Tour.Entities;
using tour.Models;

namespace tour.TourRepositories.IRepositories
{
    public interface ITourRepository
    {
        public List<Tour> GetAll();
        public Tour AddTour(TourToAdd tourToAdd);
        public Tour? GetTourById(int id);
        public bool DeleteTour(int id);
        public List<Tour> GetPopular();
    }
}
