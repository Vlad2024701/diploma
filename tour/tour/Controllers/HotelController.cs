using diploma.Db.Tour;
using diploma.Db.Tour.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using System.Net;
using tour.Models;
using tour.TourRepositories.IRepositories;
using tour.TourRepositories.Repositories;

namespace tour.Controllers
{
    [ApiController]
    [Route("api/hotel")]

    public class HotelController : ControllerBase
    {
        private readonly ILogger<HotelController> _logger;
        private readonly IHotelRepository hotelRepository;

        public HotelController(ILogger<HotelController> logger, IHotelRepository hotelRepository)
        {
            this.hotelRepository = hotelRepository;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetHotels")]
        [ProducesResponseType(typeof(List<Hotel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult GetHotels()
        {
            try
            {
                var hotels = hotelRepository.GetAll();
                if (hotels != null)
                    return Ok(hotels);
                else
                    throw new Exception();
            }
            catch (Exception ex)
            {
                return BadRequest($"Message: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("AddHotel")]
        [ProducesResponseType(typeof(Hotel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult AddHotel(HotelToAdd hotelToAdd)
        {
            try
            {
                var newHotel = hotelRepository.AddHotel(hotelToAdd);
                return Ok(newHotel);
            }
            catch (Exception ex)
            {
                return BadRequest($"Message: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("GetHotelById")]
        [ProducesResponseType(typeof(Hotel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult GetHotelById(int id)
        {
            try
            {
                var newHotel = hotelRepository.GetHotelById(id);
                return Ok(newHotel);
            }
            catch (Exception ex)
            {
                return BadRequest($"Message: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("{id}/deleteHotel")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult DeleteHotel([FromRoute]int id)
        {
            try
            {
                var hotel = hotelRepository.DeleteHotel(id);
                return Ok(hotel);
            }
            catch (Exception ex)
            {
                return BadRequest($"Message: {ex.Message}");
            }
        }
    }
}


