using diploma.Db.Tour;
using diploma.Db.Tour.Entities;

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
    }
}
