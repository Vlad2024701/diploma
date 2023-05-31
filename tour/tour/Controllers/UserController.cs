using diploma.Db.Tour;
using diploma.Db.Tour.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using System.Net;
using tour.Db;
using tour.Models;
using tour.Services;
using tour.TourRepositories.IRepositories;

namespace tour.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository userRepository;
        private readonly UserService userService;
        private readonly FillDb fillDb;

        public UserController(ILogger<UserController> logger, IUserRepository userRepository, UserService userService, FillDb fillDb)
        {
            this.userService = userService;
            this.userRepository = userRepository;
            this.fillDb = fillDb;
            _logger = logger;
        }

        [HttpGet]
        [Route("test")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Test()
        {
            try
            {
                return Ok("hello");
            }
            catch (Exception ex)
            {
                return BadRequest($"Message: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("fillDb")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult FillDb()
        {
            try
            {
                //fillDb.FillAll();
                //fillDb.FillCity();
                //fillDb.FillHotel();
                //fillDb.FillRoom();
                //fillDb.FillTour();
                //fillDb.FillTicket();
                //fillDb.FillPlace();
                //fillDb.FillTicket();
                fillDb.FillAll();
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest($"Message: {ex.Message}");
            }
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
        [Route("{id}/updateUser")]
        [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult UpdateUser([FromBody] UserUpdate user, [FromRoute] int id)
        {
            try
            {
                var newUser = userRepository.UpdateUser(user, id);
                return Ok(newUser);
            }
            catch (Exception ex)
            {
                return BadRequest($"Message: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("authorize")]
        [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Authorization(UserAuth userAuth)
        {
            try
            {
                var user = userService.Authorize(userAuth.Login, userAuth.Password);
                if (user != null)
                {
                    return Ok(user);
                }
                else
                    return BadRequest("Incorrect login or password");
            }
            catch (Exception ex)
            {
                return BadRequest($"Message: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("register")]
        [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Registration(User user)
        {
            try
            {
                var newUser = userService.Registration(user);
                if (newUser != null)
                {
                    return Ok(newUser);
                }
                else
                    return BadRequest("This login is already taken");
            }
            catch (Exception ex)
            {
                return BadRequest($"Message: {ex.Message}");
            }
        }
    }
}