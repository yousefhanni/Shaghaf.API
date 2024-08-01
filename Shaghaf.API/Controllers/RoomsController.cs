using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shaghaf.Core.Dtos;
using Shaghaf.Core.Entities.RoomEntities;
using Shaghaf.Core.Services.Contract;
using Talabat.APIs.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shaghaf.API.Controllers
{
    // The RoomsController provides endpoints to manage and retrieve room-related data
    public class RoomsController : BaseApiController
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        // Constructor to initialize room service and mapper
        public RoomsController(IRoomService roomService, IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
        }

        // Endpoint to get all rooms
        // Retrieves all rooms and returns a list of RoomDto objects
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<RoomDto>>> GetAllRooms()
        {
            var rooms = await _roomService.GetAllRooms();
            return Ok(_mapper.Map<IReadOnlyList<Room>, IReadOnlyList<RoomDto>>(rooms));
        }

        // Endpoint to get a room by ID
        // Retrieves a room by its ID and returns a RoomDto object if found, otherwise returns a 404 status
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RoomDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RoomDto>> GetRoomById(int id)
        {
            var room = await _roomService.GetRoomById(id);

            if (room is null)
                return NotFound("This Room Does not exist!!");

            return Ok(_mapper.Map<Room, RoomDto>(room));
        }

        // Endpoint to create a new room
        // Creates a new room using the details provided in the RoomToCreateDto object
        // Returns the created RoomDto object if successful, otherwise returns a 400 status
        [HttpPost]
        public async Task<ActionResult<RoomDto?>> CreateRoom(RoomToCreateDto model)
        {
            var room = await _roomService.CreateRoomAsync(model);

            if (room is null)
                return BadRequest("Invalid Create!!");

            return Ok(_mapper.Map<Room, RoomDto>(room));
        }
    }
}
