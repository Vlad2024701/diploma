using diploma.Db.Tour.Entities;
using diploma.Db.Tour;
using tour.TourRepositories.IRepositories;
using tour.Db.TourDb.Entities;

namespace tour.TourRepositories.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly TourContext tourContext;
        public TicketRepository(TourContext tourContext)
        {
            this.tourContext = tourContext;
        }

        public List<Ticket> GetTickets()
        {
            var tickets = tourContext.Ticket
                .Select(x => new Ticket
                {
                    Id = x.Id,
                    TourId = x.TourId,
                    UserId = x.UserId,
                    PlaceId = x.PlaceId,
                    RoomId = x.RoomId
                }).ToList();
            return tickets;
        }

        public List<Ticket> GetTicektsByUserId(int userId)
        {
            var tickets = tourContext.Ticket
                .Where(x => x.UserId == userId)
                .Select(x => new Ticket
                {
                    Id = x.Id,
                    TourId = x.TourId,
                    UserId = x.UserId,
                    PlaceId = x.PlaceId,
                    RoomId = x.RoomId
                }).ToList();
            return tickets;
        }
        public Ticket AddTicket(Ticket ticket)
        {
            try
            {
                tourContext.Ticket.Add(ticket);
                tourContext.SaveChanges();
                return ticket;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error when trying to add new room\nMessage: {ex.Message}");
                return null;
            }
        }

        public Ticket GetTicketById(int id)
        {
            try
            {
                var ticket = tourContext.Ticket.Where(x => x.Id == id)
                    .Select(x => new Ticket
                    {
                        Id = x.Id,
                        TourId = x.TourId,
                        UserId = x.UserId,
                        PlaceId = x.PlaceId,
                        RoomId = x.RoomId
                    }).FirstOrDefault();

                return ticket;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception message: {ex.Message}, stackTrace: {ex.StackTrace}");
                return null;
            }
        }
        public bool DeleteTicket(int id)
        {
            try
            {
                var ticket = GetTicketById(id);
                if (ticket != null)
                {
                    tourContext.Ticket.Remove(ticket);
                    tourContext.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception message: {ex.Message}, stackTrace: {ex.StackTrace}");
                return false;
            }
        }
    }
}
