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

        //[HttpPost]
        //[Route("getUser")]
        //[ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
        //[ProducesResponseType((int)HttpStatusCode.NotFound)]
        //public IActionResult GetUser(int id)
        //{
        //    try
        //    {
        //        var user = userRepository.GetUserById(id);
        //        if (user != null)
        //            return Ok(user);
        //        else
        //            throw new Exception();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest($"Message: {ex.Message}");
        //    }
        //}
    }
}


