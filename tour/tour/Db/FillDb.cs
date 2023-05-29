using diploma.Db.Tour;
using diploma.Db.Tour.Entities;
using tour.Db.TourDb.Entities;

namespace tour.Db
{
    public class FillDb
    {
        private readonly TourContext tourContext;
        
        public FillDb(TourContext tourContext)
        {
            this.tourContext = tourContext;
        }

        public void FillAll()
        {
            FillUser();
            FillCountry();
            FillCity();
            FillHotel();
            FillRoom();
            FillTour();
            FillTicket();
            FillPlace();
        }

        public void FillUser()
        {
            var listOfUsers = new List<User>()
            {
                new User(){Name = "Vlad", Login = "Vlad101", Password = "1234", Email = "sim@mail.ru", Role = "user"},
                new User(){Name = "Vlad", Login = "Vlad202", Password = "5231", Email = "sim@mail.ru", Role = "user"},
                new User(){Name = "Vlad", Login = "Vlad303", Password = "8192", Email = "sim@mail.ru", Role = "admin"},
                new User(){Name = "Vlad", Login = "Vlad404", Password = "7502", Email = "sim@mail.ru", Role = "user"}
            };
            tourContext.AddRange(listOfUsers);
            tourContext.SaveChanges();
        }

        public void FillCountry()
        {
            var listOfCountries = new List<Country>()
            {
                new Country(){Name = "Belarus"},
                new Country(){Name = "Poland"},
                new Country(){Name = "Russia"},
                new Country(){Name = "Holland"}
            };
            tourContext.AddRange(listOfCountries);
            tourContext.SaveChanges();
        }
        public void FillCity()
        {
            var listOfCities = new List<City>()
            {
                new City(){Name = "Minsk", CountryId = 1},
                new City(){Name = "Brest", CountryId = 1},
                new City(){Name = "Warsawa", CountryId = 2},
                new City(){Name = "Lublin", CountryId = 2}
            };
            tourContext.AddRange(listOfCities);
            tourContext.SaveChanges();
        }
        public void FillHotel()
        {
            var listOfHotels = new List<Hotel>()
            {
                new Hotel(){Name = "HotelName1", CityId = 1},
                new Hotel(){Name = "HotelName2", CityId = 1},
                new Hotel(){Name = "HotelName3", CityId = 1},
                new Hotel(){Name = "HotelName4", CityId = 2},
                new Hotel(){Name = "HotelName5", CityId = 2},
                new Hotel(){Name = "HotelName6", CityId = 2}
            };
            tourContext.AddRange(listOfHotels);
            tourContext.SaveChanges();
        }
        public void FillRoom()
        {
            var listOfRooms = new List<Room>()
            {
                new Room(){Name = "oneRoom", NumberOfGuests = 4, HotelBuilding = "HotelBuilding", WindowView = "WindowView", HotelId = 1},
                new Room(){Name = "twoRoom", NumberOfGuests = 2, HotelBuilding = "HotelBuilding", WindowView = "WindowView", HotelId = 1},
                new Room(){Name = "oneRoom", NumberOfGuests = 2, HotelBuilding = "HotelBuilding", WindowView = "WindowView", HotelId = 1},
                new Room(){Name = "twoRoom", NumberOfGuests = 2, HotelBuilding = "HotelBuilding", WindowView = "WindowView", HotelId = 2},
                new Room(){Name = "twoRoom", NumberOfGuests = 3, HotelBuilding = "HotelBuilding", WindowView = "WindowView", HotelId = 4},
                new Room(){Name = "oneRoom", NumberOfGuests = 1, HotelBuilding = "HotelBuilding", WindowView = "WindowView", HotelId = 4},
            };
            tourContext.AddRange(listOfRooms);
            tourContext.SaveChanges();
        }
       
        public void FillTour()
        {
            var listOfTours = new List<Tour>()
            {
                new Tour(){TourName = "Travel", TourDescription = "Some information about tour",
                    TourTimeStart = DateTime.Now, TourTimeEnd = DateTime.Now, CountryId = 1, Cost = 123.12, DepartureTime = "14:10",
                CityId = 1, HotelId = 1},
                new Tour(){TourName = "Italy", TourDescription = "Some information about tour",
                    TourTimeStart = DateTime.Now, TourTimeEnd = DateTime.Now, CountryId = 1, Cost = 133.12, DepartureTime = "14:20",
                CityId = 2, HotelId = 2},
                new Tour(){TourName = "Minsk", TourDescription = "Some information about tour",
                    TourTimeStart = DateTime.Now, TourTimeEnd = DateTime.Now, CountryId = 2, Cost = 1653.12, DepartureTime = "14:30",
                CityId = 3, HotelId = 3},
                new Tour(){TourName = "Poland", TourDescription = "Some information about tour",
                    TourTimeStart = DateTime.Now, TourTimeEnd = DateTime.Now, CountryId = 3, Cost = 456.12, DepartureTime = "14:40",
                CityId = 3, HotelId = 3}
            };
            tourContext.AddRange(listOfTours);
            tourContext.SaveChanges();
        }
        public void FillTicket()
        {
            var listOfTickets = new List<Ticket>()
            {
                new Ticket(){TourId = 1, UserLogin = "Vlad101"},
                new Ticket(){TourId = 1, UserLogin = "Vlad101"},
                new Ticket(){TourId = 2, UserLogin = "Vlad202"},
                new Ticket(){TourId = 3, UserLogin = "Vlad202"}
            };
            tourContext.AddRange(listOfTickets);
            tourContext.SaveChanges();
        }
        public void FillPlace()
        {
            var listOfPlaces = new List<Place>()
            {
                new Place(){PlaceNumber = 1, TourId = 1, IsBooked = false},
                new Place(){PlaceNumber = 2, TourId = 1, IsBooked = false},
                new Place(){PlaceNumber = 3, TourId = 1, IsBooked = false},
                new Place(){PlaceNumber = 4, TourId = 1, IsBooked = true, UserId = 1},
                new Place(){PlaceNumber = 5, TourId = 1, IsBooked = true, UserId = 2},
                new Place(){PlaceNumber = 6, TourId = 1, IsBooked = false},
                new Place(){PlaceNumber = 1, TourId = 2, IsBooked = false},
                new Place(){PlaceNumber = 2, TourId = 2, IsBooked = false},
            };
            tourContext.AddRange(listOfPlaces);
            tourContext.SaveChanges();
        }
    }
}
