using diploma.Db.Tour.Entities;

namespace tour.TourRepositories.IRepositories
{
    public interface IUserRepository
    {
        User GetUserById(int id);
        List<User> GetUsers();
        bool DeleteUser(int id);
        User CreateUser(User user);
        User UpdateUser(User user, int id);
    }
}
