using diploma.Db.Tour;
using diploma.Db.Tour.Entities;
using Microsoft.AspNetCore.Identity;
using System.Data.Entity;
using tour.Models;
using tour.TourRepositories.IRepositories;

namespace tour.TourRepositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TourContext tourContext;
        public UserRepository(TourContext tourContext) 
        {
            this.tourContext = tourContext; 
        }

        public User GetUserById(int id) 
        {
            var user = tourContext.Users.Where(x => x.Id == id)
                .Select(x => new User
                {
                    Id = x.Id,
                    Login = x.Login,
                    Password = x.Password,
                    Name = x.Name,
                    Email = x.Email,
                    Role = x.Role
                }).FirstOrDefault();
            return user;
        }

        public List<User> GetUsers()
        {
            var users = tourContext.Users
                .Select(x => new User
                {
                    Id = x.Id,
                    Login = x.Login,
                    Password = x.Password,
                    Name = x.Name,
                    Email = x.Email,
                    Role = x.Role
                }).ToList();
            return users;
        }

        public bool DeleteUser(int id) 
        {
            var user = GetUserById(id);
            if (user != null) 
            {
                tourContext.Users.Remove(user);
                tourContext.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public User CreateUser(User user) 
        {
            try
            {
                tourContext.Users.Add(user);
                tourContext.SaveChanges();
                return user;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error when trying to add ne user\nMessage: {ex.Message}");
                return user;
            }
        }

        public User UpdateUser(UserUpdate newUser, int id)
        {
            try
            {
                var oldUser = tourContext.Users.FirstOrDefault(x=>x.Id.Equals(id));

                if (oldUser != null)
                {
                    oldUser.Login = newUser.Login;
                    oldUser.Password = newUser.Password;
                    oldUser.Name = newUser.Name;
                    oldUser.Email = newUser.Email;

                    tourContext.Update(oldUser);
                    tourContext.SaveChanges();
                    return oldUser;
                }
                else
                    throw new Exception();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error when trying to update user\nMessage: {ex.Message}");
                return null;
            }
        }

    }
}
