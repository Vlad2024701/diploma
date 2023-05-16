using diploma.Db.Tour;
using diploma.Db.Tour.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using System.Net;
using tour.Db;
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
        [Route("fillDb")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult FillDb()
        {
            try
            {
                fillDb.FillAll();
                //fillDb.FillTicket();
                //fillDb.FillPlace();
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

        [HttpPost]
        [Route("authorize")]
        [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Login(string login, string password)
        {
            try
            {
                var user = userService.Authorize(login, password);
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