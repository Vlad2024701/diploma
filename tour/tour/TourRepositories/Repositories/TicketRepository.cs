using diploma.Db.Tour.Entities;
using diploma.Db.Tour;
using tour.TourRepositories.IRepositories;
using tour.Db.TourDb.Entities;
using tour.Models;
using System.Net.Sockets;

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

        public List<TicketByUserId> GetTicketsByUserId(int userId)
        {
            try
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
                var ticketsByUserId = new List<TicketByUserId>();
                foreach (var ticket in tickets)
                {
                    var ticketByUserId = new TicketByUserId();
                    ticketByUserId.Id = ticket.Id;
                    ticketByUserId.TourName = tourContext.Tours.Where(x => x.Id == ticket.TourId).Select(x => x.TourName).FirstOrDefault();
                    ticketByUserId.TourTimeStart = tourContext.Tours.Where(x => x.Id == ticket.TourId).Select(x => x.TourTimeStart).FirstOrDefault();
                    ticketByUserId.TourTimeEnd = tourContext.Tours.Where(x => x.Id == ticket.TourId).Select(x => x.TourTimeEnd).FirstOrDefault();
                    var allPlacesForTour = tourContext.Tours.Where(x => x.Id == ticket.TourId).Select(x => x.Places).FirstOrDefault();
                    var placeNumbers = allPlacesForTour.Where(x => x.IsBooked).Select(x => x.PlaceNumber).ToList();
                    ticketByUserId.PlaceNumbers = placeNumbers;
                    foreach(var ticketBUI in ticketsByUserId)
                    {
                        if (ticketBUI.TourName == ticketByUserId.TourName)
                            continue;
                        else
                            ticketsByUserId.Add(ticketByUserId);
                    }
                }
            return ticketsByUserId;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception message: {ex.Message}, stackTrace: {ex.StackTrace}");
                return null;
            }
        }
        public bool AddTicket(TicketToAdd ticketToAdd)
        {
            try
            {
                var allPlacesForTour = tourContext.Tours.Where(x => x.Id == ticketToAdd.TourId).Select(x => x.Places).FirstOrDefault();
                var freePlacesId = allPlacesForTour.Where(x => !x.IsBooked).Select(x => x.Id).Take(ticketToAdd.PlacesCount).ToList();
                var addedTicketsList = new List<Ticket>();
                foreach(var placeId in freePlacesId) 
                {
                    var ticket = new Ticket();
                    ticket.TourId = ticketToAdd.TourId;
                    ticket.RoomId = ticketToAdd.RoomId;
                    var place = tourContext.Places.Where(x => x.Id == placeId).FirstOrDefault();
                    place.IsBooked = true;
                    place.UserId = ticketToAdd.UserId;
                    tourContext.SaveChanges();
                    ticket.UserId = ticketToAdd.UserId;
                    ticket.PlaceId = placeId;
                    addedTicketsList.Add(ticket);
                    tourContext.Ticket.Add(ticket);
                    tourContext.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error when trying to add new room\nMessage: {ex.Message}");
                return false;
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
