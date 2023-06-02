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
            //FillHotel();
            //FillRoom();
            //FillTour();
            //FillPlace();
            //FillTicket();
        }

        public void FillUser()
        {
            var listOfUsers = new List<User>()
            {
                new User(){Name = "Владислав", Login = "Vlad101", Password = "1234", Email = "sim@mail.ru", Role = "user"},
                new User(){Name = "Владислав", Login = "Vlad202", Password = "5231", Email = "sim@mail.ru", Role = "user"},
                new User(){Name = "Владислав", Login = "Vlad303", Password = "1234", Email = "sim@mail.ru", Role = "admin"},
                new User(){Name = "Владислав", Login = "Vlad404", Password = "7502", Email = "sim@mail.ru", Role = "user"}
            };
            tourContext.AddRange(listOfUsers);
            tourContext.SaveChanges();
        }

        public void FillCountry()
        {
            var listOfCountries = new List<Country>()
            {
                new Country(){Name = "Беларусь"},
                new Country(){Name = "Польша"},
                new Country(){Name = "Россия"},
                new Country(){Name = "Америка"}
            };
            tourContext.AddRange(listOfCountries);
            tourContext.SaveChanges();
        }
        public void FillCity()
        {
            var listOfCities = new List<City>()
            {
                new City(){Name = "Минск", CountryId = 1},
                new City(){Name = "Брест", CountryId = 1},
                new City(){Name = "Варшава", CountryId = 2},
                new City(){Name = "Люблинь", CountryId = 2},
                new City(){Name = "Москва", CountryId = 3},
                new City(){Name = "Пермь", CountryId = 3},
                new City(){Name = "Калифорния", CountryId = 4}
            };
            tourContext.AddRange(listOfCities);
            tourContext.SaveChanges();
        }
        public void FillHotel()
        {
            var listOfHotels = new List<Hotel>()
            {
                new Hotel(){Name = "Турист", CityId = 1},
                new Hotel(){Name = "Испанка", CityId = 1},
                new Hotel(){Name = "Корчма", CityId = 1},
                new Hotel(){Name = "Мотель", CityId = 2},
                new Hotel(){Name = "Альбинос", CityId = 3},
                new Hotel(){Name = "Валерий", CityId = 3}
            };
            tourContext.AddRange(listOfHotels);
            tourContext.SaveChanges();
        }
        public void FillRoom()
        {
            var listOfRooms = new List<Room>(){
                new Room(){Name = "Однокомнатный для одного гостя", NumberOfGuests = 1, HotelBuilding = "Основное здание отеля", WindowView = "На море", HotelId = 1},
                new Room(){Name = "Однокомнатный для двух гостей", NumberOfGuests = 2, HotelBuilding = "Основное здание отеля", WindowView = "На сад", HotelId = 1},
                new Room(){Name = "Двухкомнатный для двух гостей", NumberOfGuests = 2, HotelBuilding = "Основное здание отеля", WindowView = "На город", HotelId = 1},
                new Room(){Name = "Духкомнатный для четырёх гостей", NumberOfGuests = 4, HotelBuilding = "Основное здание отеля", WindowView = "На океан", HotelId = 1},
                new Room(){Name = "Студия для одного-двух гостей", NumberOfGuests = 2, HotelBuilding = "Основное здание отеля", WindowView = "На лагуну", HotelId = 1},
                new Room(){Name = "Люкс для 2 гостей", NumberOfGuests = 2, HotelBuilding = "Основное здание отеля", WindowView = "На дзюны", HotelId = 1},
                new Room(){Name = "Семейная комнта для четырёх и более гостей", NumberOfGuests = 6, HotelBuilding = "Основное здание отеля", WindowView = "На горы", HotelId = 1},
                new Room(){Name = "Комната для молодожёнов", NumberOfGuests = 2, HotelBuilding = "Основное здание отеля", WindowView = "На море", HotelId = 1},
                new Room(){Name = "Сьют для двух и более гостей", NumberOfGuests = 6, HotelBuilding = "Основное здание отеля", WindowView = "На море", HotelId = 1},
                new Room(){Name = "Сьют повышенной комфортности для двух и более гостей", NumberOfGuests = 8, HotelBuilding = "Коттедж", WindowView = "На море", HotelId = 1},
                new Room(){Name = "Бунгало для 2 и более гостей", NumberOfGuests = 6, HotelBuilding = "Бунгало", WindowView = "На море", HotelId = 1},
                new Room(){Name = "Однокомнатный для одного гостя", NumberOfGuests = 1, HotelBuilding = "Основное здание отеля", WindowView = "На море", HotelId = 2},
                new Room(){Name = "Бунгало для 2 и более гостей", NumberOfGuests = 6, HotelBuilding = "Бунгало", WindowView = "На море", HotelId = 2},
                new Room(){Name = "Сьют для двух и более гостей", NumberOfGuests = 6, HotelBuilding = "Основное здание отеля", WindowView = "На море", HotelId = 2},
            };
            tourContext.AddRange(listOfRooms);
            tourContext.SaveChanges();
        }
       
        public void FillTour()
        {
            var listOfTours = new List<Tour>()
            {
                new Tour(){TourName = "Путешествие в Минск", TourDescription = "Посетите столицу Беларуси и все её достопримечательности",
                    TourTimeStart = DateTime.Now, TourTimeEnd = DateTime.Now, CountryId = 1, Cost = 123.12, DepartureTime = "14:10",
                CityId = 1, HotelId = 1},
                new Tour(){TourName = "Туристичскиая поездка в Минск", TourDescription = "Посетите столицу Беларуси и замки в Минской области",
                    TourTimeStart = DateTime.Now, TourTimeEnd = DateTime.Now, CountryId = 1, Cost = 133.12, DepartureTime = "14:20",
                CityId = 1, HotelId = 2},
                new Tour(){TourName = "Туристическая поездка в Варшаву", TourDescription = "Туристическая поездка в Варшаву",
                    TourTimeStart = DateTime.Now, TourTimeEnd = DateTime.Now, CountryId = 2, Cost = 1653.12, DepartureTime = "14:30",
                CityId = 3, HotelId = 4},
                new Tour(){TourName = "Путешесвтие в Варшаву", TourDescription = "Путешествие в Варшаву",
                    TourTimeStart = DateTime.Now, TourTimeEnd = DateTime.Now, CountryId = 2, Cost = 456.12, DepartureTime = "14:40",
                CityId = 3, HotelId = 6}
            };
            tourContext.AddRange(listOfTours);
            tourContext.SaveChanges();
        }
        public void FillTicket()
        {
            var listOfTickets = new List<Ticket>()
            {
                new Ticket(){TourId = 1, UserId = 1, PlaceId = 1, RoomId = 1},
                new Ticket(){TourId = 1, UserId = 2, PlaceId = 7, RoomId = 2},
                new Ticket(){TourId = 2, UserId = 2, PlaceId = 8, RoomId = 13},
                new Ticket(){TourId = 2, UserId = 2, PlaceId = 9, RoomId = 14}
            };
            tourContext.AddRange(listOfTickets);
            tourContext.SaveChanges();
        }
        public void FillPlace()
        {
            var listOfPlaces = new List<Place>()
            {
                new Place(){PlaceNumber = 1, TourId = 1, IsBooked = true, UserId = 1},
                new Place(){PlaceNumber = 2, TourId = 1, IsBooked = false},
                new Place(){PlaceNumber = 3, TourId = 1, IsBooked = false},
                new Place(){PlaceNumber = 4, TourId = 1, IsBooked = false},
                new Place(){PlaceNumber = 5, TourId = 1, IsBooked = false},
                new Place(){PlaceNumber = 6, TourId = 1, IsBooked = false},
                new Place(){PlaceNumber = 1, TourId = 2, IsBooked = true, UserId = 2},
                new Place(){PlaceNumber = 2, TourId = 2, IsBooked = true, UserId = 2},
                new Place(){PlaceNumber = 2, TourId = 3, IsBooked = true, UserId = 2},
                new Place(){PlaceNumber = 2, TourId = 3, IsBooked = false},
            };
            tourContext.AddRange(listOfPlaces);
            tourContext.SaveChanges();
        }
    }
}
