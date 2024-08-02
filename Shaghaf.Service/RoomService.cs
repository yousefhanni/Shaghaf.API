using AutoMapper;
using Shaghaf.Core;
using Shaghaf.Core.Dtos;
using Shaghaf.Core.Entities.RoomEntities;
using Shaghaf.Core.Services.Contract;



namespace Shaghaf.Service
{
    public class RoomService : IRoomService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        // Constructor to initialize dependencies
        public RoomService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // Create a new room asynchronously
        public async Task<Room?> CreateRoomAsync(RoomToCreateDto model)
        {
            var roomRepo = _unitOfWork.Repository<Room>();
            var room = _mapper.Map<Room>(model);

            roomRepo.Add(room);
            var result = await _unitOfWork.CompleteAsync();
            if (result <= 0) return null;

            return room;
        }

        // Get all rooms 
        public async Task<IReadOnlyList<Room>> GetAllRooms()
        {
            var roomRepo = _unitOfWork.Repository<Room>();
            var rooms = await roomRepo.GetAllAsync();
            var roomslist = rooms.ToList();
            return roomslist;
        }

        // Get room details by ID 
        public async Task<Room?> GetRoomById(int roomId)
        {
            var roomRepo = _unitOfWork.Repository<Room>();
            var room = await roomRepo.GetByIdAsync(roomId);

            if (room is null)
                return null;
            return room;
        }
    }
}