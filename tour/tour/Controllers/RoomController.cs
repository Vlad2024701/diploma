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
    [Route("api/room")]

    public class RoomController : ControllerBase
    {
        private readonly ILogger<RoomController> _logger;
        private readonly IRoomRepository roomRepository;

        public RoomController(ILogger<RoomController> logger, IRoomRepository roomRepository)
        {
            this.roomRepository = roomRepository;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetRooms")]
        [ProducesResponseType(typeof(List<Room>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult GetRooms()
        {
            try
            {
                var rooms = roomRepository.GetRooms();
                if (rooms != null)
                    return Ok(rooms);
                else
                    throw new Exception();
            }
            catch (Exception ex)
            {
                return BadRequest($"Message: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("GetRoomById")]
        [ProducesResponseType(typeof(Room), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult GetRoomById(int id)
        {
            try
            {
                var room = roomRepository.GetRoomById(id);
                if (room != null)
                    return Ok(room);
                else
                    throw new Exception();
            }
            catch (Exception ex)
            {
                return BadRequest($"Message: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("AddRoom")]
        [ProducesResponseType(typeof(Room), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult AddRoom(Room room)
        {
            try
            {
                var newRoom = roomRepository.AddRoom(room);
                return Ok(newRoom);
            }
            catch (Exception ex)
            {
                return BadRequest($"Message: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("deleteRoom")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult DeleteRoom(int id)
        {
            try
            {
                var room = roomRepository.DeleteRoom(id);
                return Ok(room);
            }
            catch (Exception ex)
            {
                return BadRequest($"Message: {ex.Message}");
            }
        }
    }
}


