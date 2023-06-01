using diploma.Db.Tour.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using tour.Db.TourDb.Entities;
using tour.Models;
using tour.TourRepositories.IRepositories;

namespace tour.Controllers
{
    [ApiController]
    [Route("api/ticket")]
    public class TicketController : ControllerBase
    {
        private readonly ILogger<CountryController> _logger;
        private readonly ITicketRepository ticketRepository;

        public TicketController(ILogger<CountryController> logger, ITicketRepository ticketRepository)
        {
            this.ticketRepository = ticketRepository;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetTickets")]
        [ProducesResponseType(typeof(List<Ticket>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult GetTickets()
        {
            try
            {
                var tickets= ticketRepository.GetTickets();
                if (tickets != null)
                    return Ok(tickets);
                else
                    throw new Exception();
            }
            catch (Exception ex)
            {
                return BadRequest($"Message: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("AddTicket")]
        [ProducesResponseType(typeof(List<Ticket>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult AddTicket(TicketToAdd ticketToAdd)
        {
            try
            {
                var newTicketsList = ticketRepository.AddTicket(ticketToAdd);
                return Ok(newTicketsList);
            }
            catch (Exception ex)
            {
                return BadRequest($"Message: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("{userId}/GetTicketsByUserId")]
        [ProducesResponseType(typeof(List<TicketByUserId>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult GetTicketsByUserId([FromRoute]int userId)
        {
            try
            {
                var ticketsForUser = ticketRepository.GetTicketsByUserId(userId);
                if (ticketsForUser != null)
                    return Ok(ticketsForUser);
                else
                {
                    var newErrorMessage = new ErrorMessage() { Message = "No booked ticket" };
                    return BadRequest(newErrorMessage.Message);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Message: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("GetTicektById")]
        [ProducesResponseType(typeof(Ticket), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult GetTicektById(int id)
        {
            try
            {
                var ticket = ticketRepository.GetTicketById(id);
                if (ticket != null)
                    return Ok(ticket);
                else
                {
                    var newErrorMessage = new ErrorMessage() { Message = "No ticket" };
                    return BadRequest(newErrorMessage.Message);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Message: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("deleteTicket")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult DeleteTicket(int id)
        {
            try
            {
                var ticketIsDeleted = ticketRepository.DeleteTicket(id);
                return Ok(ticketIsDeleted);
            }
            catch (Exception ex)
            {
                return BadRequest($"Message: {ex.Message}");
            }
        }
    }
}
