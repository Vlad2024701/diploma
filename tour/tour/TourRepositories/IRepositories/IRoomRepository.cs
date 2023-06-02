using diploma.Db.Tour.Entities;
using tour.Models;

namespace tour.TourRepositories.IRepositories
{
    public interface IRoomRepository
    {
        List<Room> GetRooms();
        Room AddRoom(RoomToAdd roomToAdd);
        bool DeleteRoom(int id);
        Room GetRoomById(int id);
        public List<Room> GetRoomByHotelId(int hotelId);
    }
}
