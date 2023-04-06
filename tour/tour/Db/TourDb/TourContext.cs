using diploma.Db.Tour.Entities;
using Microsoft.EntityFrameworkCore;
using tour.Db.TourDb.Entities;

namespace diploma.Db.Tour
{
    public partial class TourContext : DbContext
    {

        public TourContext(DbContextOptions<TourContext> options) : base (options) { }

        public virtual DbSet<Entities.Tour> Tours { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Place> Places { get; set; }

    }
}
