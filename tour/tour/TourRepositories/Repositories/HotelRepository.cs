using diploma.Db.Tour.Entities;
using diploma.Db.Tour;
using tour.TourRepositories.IRepositories;
using tour.Models;

namespace tour.TourRepositories.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly TourContext tourContext;
        private readonly IRoomRepository roomRepository;
        private readonly ITourRepository tourRepository;

        public HotelRepository(TourContext tourContext, IRoomRepository roomRepository, ITourRepository tourRepository)
        {
            this.tourContext = tourContext;
            this.roomRepository = roomRepository;
            this.tourRepository = tourRepository;
        }
        public List<Hotel> GetAll()
        {
            var hotels = tourContext.Hotels
                .Select(x => new Hotel
                {
                    Id = x.Id,
                    Name = x.Name,
                    CityId = x.CityId,
                    Rooms = x.Rooms,
                    ImageURL = x.ImageURL,
                    HotelDescription = x.HotelDescription
                }).ToList();
            return hotels;
        }

        public Hotel AddHotel(HotelToAdd hotelToAdd)
        {
            try
            {
                var hotel = new Hotel()
                {
                    ImageURL = hotelToAdd.ImageURL,
                    Name = hotelToAdd.Name,
                    CityId = hotelToAdd.CityId,
                    HotelDescription = hotelToAdd.HotelDescription
                };
                tourContext.Hotels.Add(hotel);
                tourContext.SaveChanges();
                return hotel;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error when trying to add new hotel\nMessage: {ex.Message}");
                return null;
            }
        }

        public Hotel GetHotelById(int id)
        {
            try
            {
                var hotel = tourContext.Hotels.Where(x => x.Id == id)
                    .Select(x => new Hotel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        CityId = x.CityId,
                        Rooms = x.Rooms,
                        ImageURL = x.ImageURL,
                        HotelDescription = x.HotelDescription
                    }).FirstOrDefault();
                return hotel;
            }
            catch(Exception ex)
            {
                Console.WriteLine("No such hotelId");
                return null;
            }
        }
        public bool DeleteHotel(int id)
        {
            try
            {
                var hotel = GetHotelById(id);
                var roomsId = tourContext.Rooms.Where(x=>x.HotelId == id).Select(x=>x.Id).ToList();
                foreach (var roomId in roomsId) 
                {
                    roomRepository.DeleteRoom(roomId);
                }
                var toursId = tourContext.Tours.Where(x => x.HotelId == id).Select(x => x.Id).ToList();
                foreach (var tourId in toursId)
                {
                    tourRepository.DeleteTour(tourId);
                }
                if (hotel != null)
                {
                    tourContext.Hotels.Remove(hotel);
                    tourContext.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex) 
            {
                Console.WriteLine("No such hotelId");
                return false;
            } 
        }
    }
}
