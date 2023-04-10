using diploma.Db.Tour.Entities;

namespace tour.TourRepositories.IRepositories
{
    public interface ITourRepository
    {
        List<Tour> GetAll();
        Tour AddTour(Tour tour);
        Tour? GetTourById(int id);
        bool DeleteTour(int id);
    }
}
