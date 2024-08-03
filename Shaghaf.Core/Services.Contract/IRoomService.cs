using Shaghaf.Core.Dtos;

namespace Shaghaf.Core.Services.Contract
{
    public interface IRoomService
    {
        Task<RoomDto> CreateRoomAsync(RoomToCreateDto roomDto);
        Task UpdateRoomAsync(RoomDto roomDto);
        Task<RoomDto?> GetRoomByIdAsync(int id);
        Task<IReadOnlyList<RoomDto>> GetAllRoomsAsync();
    }
}
