using diploma.Db.Tour.Entities;
using tour.Models;

namespace tour.TourRepositories.IRepositories
{
    public interface IHotelRepository
    {
        List<Hotel> GetAll();
        Hotel AddHotel(HotelToAdd hotelToAdd);
        bool DeleteHotel(int id);
        Hotel GetHotelById(int id);
    }
}
