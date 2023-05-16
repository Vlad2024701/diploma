using diploma.Db.Tour.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using tour.Db.TourDb.Entities;
using tour.TourRepositories.IRepositories;

namespace tour.Controllers
{
    public class PlaceController : ControllerBase
    {
        private readonly ILogger<PlaceController> _logger;
        private readonly IPlaceRepository placeRepository;

        public PlaceController(ILogger<PlaceController> logger, IPlaceRepository placeRepository)
        {
            this.placeRepository = placeRepository;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetPlaces")]
        [ProducesResponseType(typeof(List<Place>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult GetPlaces()
        {
            try
            {
                var places = placeRepository.GetAll();
                if (places != null)
                    return Ok(places);
                else
                    throw new Exception();
            }
            catch (Exception ex)
            {
                return BadRequest($"Message: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("GetPlaceByTourId")]
        [ProducesResponseType(typeof(List<Place>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult GetPlacesForTour(int tourId)
        {
            try
            {
                var places = placeRepository.GetPlacesByTourId(tourId);
                if (places != null)
                    return Ok(places);
                else
                    throw new Exception();
            }
            catch (Exception ex)
            {
                return BadRequest($"Message: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("AddPlace")]
        [ProducesResponseType(typeof(Place), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult AddCity(Place place)
        {
            try
            {
                var newPlace = placeRepository.AddPlace(place);
                return Ok(newPlace);
            }
            catch (Exception ex)
            {
                return BadRequest($"Message: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("deletePlace")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult DeletePlace(int id)
        {
            try
            {
                var place = placeRepository.DeletePlace(id);
                return Ok(place);
            }
            catch (Exception ex)
            {
                return BadRequest($"Message: {ex.Message}");
            }
        }
    }
}
