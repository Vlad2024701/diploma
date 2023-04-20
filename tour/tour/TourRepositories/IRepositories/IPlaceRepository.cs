using tour.Db.TourDb.Entities;

namespace tour.TourRepositories.IRepositories
{
    public interface IPlaceRepository
    {
        List<Place> GetAll();
        Place AddPlace(Place place);
        Place GetPlaceById(int id);
        List<IList<Place>> GetPlacesByTourId(int tourId);
        bool DeletePlace(int id);
    }
}
