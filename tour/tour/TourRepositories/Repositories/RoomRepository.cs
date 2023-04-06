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
                    WindowView = x.WindowView
                }).ToList();
            return rooms;
        }
    }
}
