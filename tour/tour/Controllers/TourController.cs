using diploma.Db.Tour;
using diploma.Db.Tour.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using System.Net;
using tour.TourRepositories.IRepositories;
using tour.TourRepositories.Repositories;

namespace tour.Controllers
{
    [ApiController]
    [Route("api/tour")]

    public class TourController : ControllerBase
    {
        private readonly ILogger<TourController> _logger;
        private readonly ITourRepository tourRepository;

        public TourController(ILogger<TourController> logger, ITourRepository tourRepository)
        {
            this.tourRepository = tourRepository;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetTours")]
        [ProducesResponseType(typeof(List<Tour>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult GetTours()
        {
            try
            {
                var tours = tourRepository.GetAll();
                if (tours != null)
                    return Ok(tours);
                else
                    throw new Exception();
            }
            catch (Exception ex)
            {
                return BadRequest($"Message: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("GetTour")]
        [ProducesResponseType(typeof(Tour), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult GetTours(int id)
        {
            try
            {
                var tour = tourRepository.GetTourById(id);
                if (tour != null)
                    return Ok(tour);
                else
                    throw new Exception();
            }
            catch (Exception ex)
            {
                return BadRequest($"Message: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("AddTour")]
        [ProducesResponseType(typeof(Tour), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult AddTour(Tour tour)
        {
            try
            {
                var newTour = tourRepository.AddTour(tour);
                return Ok(newTour);
            }
            catch (Exception ex)
            {
                return BadRequest($"Message: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("deleteTour")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult DeleteTour(int id)
        {
            try
            {
                var tour = tourRepository.DeleteTour(id);
                return Ok(tour);
            }
            catch (Exception ex)
            {
                return BadRequest($"Message: {ex.Message}");
            }
        }
    }
}


