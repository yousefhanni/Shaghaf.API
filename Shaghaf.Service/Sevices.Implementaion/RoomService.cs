using AutoMapper;
using Shaghaf.Core.Dtos;
using Shaghaf.Core.Entities.RoomEntities;
using Shaghaf.Core.Services.Contract;
using Shaghaf.Core;
using Shaghaf.Core.Specifications;
using System.Collections.Generic;
using System.Threading.Tasks;

public class RoomService : IRoomService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RoomService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<RoomDto> CreateRoomAsync(RoomToCreateDto roomDto)
    {
        var room = _mapper.Map<Room>(roomDto);
        _unitOfWork.Repository<Room>().AddAsync(room);
        await _unitOfWork.CompleteAsync();
        return _mapper.Map<RoomDto>(room);
    }

    public async Task UpdateRoomAsync(RoomDto roomDto)
    {
        var room = await _unitOfWork.Repository<Room>().GetByIdAsync(roomDto.Id);
        if (room == null)
        {
            throw new KeyNotFoundException("No room found matching the specified criteria.");
        }

        _mapper.Map(roomDto, room);
        _unitOfWork.Repository<Room>().Update(room);
        await _unitOfWork.CompleteAsync();
    }

    public async Task<RoomDto?> GetRoomByIdAsync(int id)
    {
        var room = await _unitOfWork.Repository<Room>().GetByIdAsync(id);
        return room == null ? null : _mapper.Map<RoomDto>(room);
    }

    public async Task<IReadOnlyList<RoomDto>> GetAllRoomsAsync()
    {
        var rooms = await _unitOfWork.Repository<Room>().GetAllAsync();
        return _mapper.Map<IReadOnlyList<RoomDto>>(rooms);
    }

    public async Task<IReadOnlyList<RoomDto>> GetRoomsWithSpecAsync(ISpecifications<Room> spec)
    {
        var rooms = await _unitOfWork.Repository<Room>().GetAllWithSpecAsync(spec);
        return _mapper.Map<IReadOnlyList<RoomDto>>(rooms);
    }
}
