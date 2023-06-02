using diploma.Db.Tour;
using diploma.Db.Tour.Entities;
using tour.Models;
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
                    HotelId = x.HotelId,
                    ImageURL = x.ImageURL
                }).ToList();
            return rooms;
        }
        public Room AddRoom(RoomToAdd roomToAdd)
        {
            try
            {
                var room = new Room()
                {
                    ImageURL = roomToAdd.ImageURL,
                    Name = roomToAdd.Name,
                    NumberOfGuests = roomToAdd.NumberOfGuests,
                    HotelBuilding = roomToAdd.HotelBuilding,
                    WindowView = roomToAdd.WindowView,
                    HotelId = roomToAdd.HotelId
                };
                tourContext.Rooms.Add(room);
                tourContext.SaveChanges();
                return room;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error when trying to add new room\nMessage: {ex.Message}");
                return null;
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
                        HotelId = x.HotelId,
                        ImageURL = x.ImageURL
                    }).FirstOrDefault();
                return room;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception message: {ex.Message}, stackTrace: {ex.StackTrace}");
                return null;
            }
        }
        public List<Room> GetRoomByHotelId(int hotelId)
        {
            try
            {
                var rooms = tourContext.Rooms.Where(x => x.HotelId == hotelId)
                    .Select(x => new Room
                    {
                        Id = x.Id,
                        Name = x.Name,
                        HotelBuilding = x.HotelBuilding,
                        WindowView = x.WindowView,
                        HotelId = x.HotelId,
                        ImageURL = x.ImageURL
                    }).ToList();
                return rooms;
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
                var tickets = tourContext.Ticket.Where(x => x.RoomId == id).ToList();
                if (tickets != null) 
                {
                    tourContext.Ticket.RemoveRange(tickets);
                    tourContext.SaveChanges();
                }

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
