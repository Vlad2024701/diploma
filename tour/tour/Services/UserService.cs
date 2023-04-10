using diploma.Db.Tour;
using diploma.Db.Tour.Entities;
using tour.TourRepositories.IRepositories;

namespace tour.Services
{
    public class UserService
    {
        private readonly TourContext tourContext;
        private readonly IUserRepository userRepository;
        public UserService(TourContext tourContext, IUserRepository userRepository) 
        {
            this.userRepository = userRepository;
            this.tourContext = tourContext;
        }

        public User? Authorize(string login, string password)
        {
            var user = tourContext.Users
                .Where(x => x.Login == login && x.Password == password)
                .Select(x => new User
                {
                    Id = x.Id,
                    Email = x.Email,
                    Login = x.Login,
                    Password = x.Password,
                    Name = x.Name,
                    Role = x.Role,
                }).FirstOrDefault();
            return user;
        }

        public User? Registration(User user)
        {
            var logins = tourContext.Users
                .Select(x => x.Login).ToList();
            if (logins.Contains(user.Login))
            {
                return null;
            }
            userRepository.CreateUser(user);
            return user;
        }
    }
}
