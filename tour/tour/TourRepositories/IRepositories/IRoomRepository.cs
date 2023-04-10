using diploma.Db.Tour.Entities;

namespace tour.TourRepositories.IRepositories
{
    public interface IRoomRepository
    {
        List<Room> GetRooms();
        Room AddRoom(Room room);
        bool DeleteRoom(int id);
        Room GetRoomById(int id);
    }
}
