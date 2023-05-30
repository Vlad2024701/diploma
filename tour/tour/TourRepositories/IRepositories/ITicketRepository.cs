using diploma.Db.Tour.Entities;
using tour.Db.TourDb.Entities;

namespace tour.TourRepositories.IRepositories
{
    public interface ITicketRepository
    {
        List<Ticket> GetTickets();
        Ticket AddTicket(Ticket ticket);
        bool DeleteTicket(int id);
        Ticket GetTicketById(int id);
        List<Ticket> GetTicektsByUserId(int userId);
    }
}
