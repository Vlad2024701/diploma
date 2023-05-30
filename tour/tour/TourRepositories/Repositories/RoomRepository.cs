using diploma.Db.Tour;
using diploma.Db.Tour.Entities;
using tour.TourRepositories.IRepositories;

namespace tour.TourRepositories.Repositories
{
    public class RoomRepository : IRoomRepository
    {

        private readonly TourContext tourContext;
        public RoomRepository(TourContext tourContext) 
        {
            this.tourContext = tourContext;
        }

        public List<Room> GetRooms() 
        {
            var rooms = tourContext.Rooms
                .Select(x => new Room
                {
                    Id = x.Id,
                    Name = x.Name,
                    NumberOfGuests = x.NumberOfGuests,
                    HotelBuilding = x.HotelBuilding,
                    WindowView = x.WindowView,
                    HotelId = x.HotelId
                }).ToList();
            return rooms;
        }
        public Room AddRoom(Room room)
        {
            try
            {
                tourContext.Rooms.Add(room);
                tourContext.SaveChanges();
                return room;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error when trying to add new room\nMessage: {ex.Message}");
                return room;
            }
        }

        public Room GetRoomById(int id)
        {
            try
            {
                var room = tourContext.Rooms.Where(x => x.Id == id)
                    .Select(x => new Room
                    {
                        Id = x.Id,
                        Name = x.Name,
                        HotelBuilding = x.HotelBuilding,
                        WindowView = x.WindowView,
                        HotelId = x.HotelId
                    }).FirstOrDefault();
                return room;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception message: {ex.Message}, stackTrace: {ex.StackTrace}");
                return null;
            }
        }
        public bool DeleteRoom(int id)
        {
            try
            {
                var room = GetRoomById(id);
                if (room != null)
                {
                    tourContext.Rooms.Remove(room);
                    tourContext.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception message: {ex.Message}, stackTrace: {ex.StackTrace}");
                return false;
            }
        }
    }
}
