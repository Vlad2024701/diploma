using diploma.Db.Tour.Entities;
using diploma.Db.Tour;
using tour.TourRepositories.IRepositories;

namespace tour.TourRepositories.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly TourContext tourContext;

        public HotelRepository(TourContext tourContext)
        {
            this.tourContext = tourContext;
        }
        public List<Hotel> GetAll()
        {
            var hotels = tourContext.Hotels
                .Select(x => new Hotel
                {
                    Id = x.Id,
                    Name = x.Name,
                    CityId = x.CityId,
                    Rooms = x.Rooms
                }).ToList();
            return hotels;
        }

        public Hotel AddHotel(Hotel hotel)
        {
            try
            {
                tourContext.Hotels.Add(hotel);
                tourContext.SaveChanges();
                return hotel;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error when trying to add new hotel\nMessage: {ex.Message}");
                return hotel;
            }
        }

        public Hotel GetHotelById(int id)
        {
            var hotel = tourContext.Hotels.Where(x => x.Id == id)
                .Select(x => new Hotel
                {
                    Id = x.Id,
                    Name = x.Name,
                    CityId = x.CityId
                }).FirstOrDefault();
            return hotel;
        }
        public bool DeleteHotel(int id)
        {
            var hotel = GetHotelById(id);
            if (hotel != null)
            {
                tourContext.Hotels.Remove(hotel);
                tourContext.SaveChanges();
                return true;
            }
            else
                return false;
        }
    }
}
