using diploma.Db.Tour;
using diploma.Db.Tour.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using System.Net;
using tour.TourRepositories.IRepositories;

namespace tour.Controllers
{
    [ApiController]
    [Route("api/city")]

    public class CityController : ControllerBase
    {
        private readonly ILogger<CityController> _logger;
        private readonly ICityRepository cityRepository;

        public CityController(ILogger<CityController> logger, ICityRepository cityRepository)
        {
            this.cityRepository = cityRepository;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetCities")]
        [ProducesResponseType(typeof(List<City>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult GetCities()
        {
            try
            {
                var cities = cityRepository.GetAll();
                if (cities != null)
                    return Ok(cities);
                else
                    throw new Exception();
            }
            catch (Exception ex)
            {
                return BadRequest($"Message: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("AddCity")]
        [ProducesResponseType(typeof(City), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult AddCity(City city)
        {
            try
            {
                var newCity = cityRepository.AddCity(city);
                return Ok(newCity);
            }
            catch (Exception ex)
            {
                return BadRequest($"Message: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("deleteCity")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                var city = cityRepository.DeleteCity(id);
                return Ok(city);
            }
            catch (Exception ex)
            {
                return BadRequest($"Message: {ex.Message}");
            }
        }
    }
}


