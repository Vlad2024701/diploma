using diploma.Db.Tour.Entities;

namespace tour.TourRepositories.IRepositories
{
    public interface IHotelRepository
    {
        List<Hotel> GetAll();
        Hotel AddHotel(Hotel hotel);
        bool DeleteHotel(int id);
        Hotel GetHotelById(int id);
    }
}
