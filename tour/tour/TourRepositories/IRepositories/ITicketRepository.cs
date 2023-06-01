using diploma.Db.Tour.Entities;
using tour.Db.TourDb.Entities;
using tour.Models;

namespace tour.TourRepositories.IRepositories
{
    public interface ITicketRepository
    {
        List<Ticket> GetTickets();
        bool AddTicket(TicketToAdd ticket);
        bool DeleteTicket(int id);
        Ticket GetTicketById(int id);
        List<TicketByUserId> GetTicketsByUserId(int userId);
    }
}
