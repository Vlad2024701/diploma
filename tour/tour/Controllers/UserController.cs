using diploma.Db.Tour;
using diploma.Db.Tour.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using System.Net;
using tour.TourRepositories.IRepositories;

namespace tour.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository userRepository;

        public UserController(ILogger<UserController> logger, IUserRepository userRepository)
        {
            this.userRepository =userRepository;
            _logger = logger;
        }
        [HttpPost]
        [Route("getUser")]
        [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult GetUser(int id)
        {
            try
            {
                var user = userRepository.GetUserById(id);
                if (user != null)
                    return Ok(user);
                else
                    throw new Exception();
            }
            catch (Exception ex)
            {
                return BadRequest($"Message: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("getUsers")]
        [ProducesResponseType(typeof(List<User>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult GetUsers()
        {
            try
            {
                var users = userRepository.GetUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest($"Message: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("deleteUser")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                var users = userRepository.DeleteUser(id);
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest($"Message: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("createUser")]
        [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult AddUser(User user)
        {
            try
            {
                var newUser = userRepository.CreateUser(user);
                return Ok(newUser);
            }
            catch (Exception ex)
            {
                return BadRequest($"Message: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("updateUser")]
        [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult UpdateUser([FromBody] User user, int id)
        {
            try
            {
                user.Id = id;
                var newUser = userRepository.UpdateUser(user, id);
                return Ok(newUser);
            }
            catch (Exception ex)
            {
                return BadRequest($"Message: {ex.Message}");
            }
        }
    }
}