using Shaghaf.Core.Dtos;
using Shaghaf.Core.Entities.RoomEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Shaghaf.Core.Services.Contract
{
    public interface IRoomService
    {
        Task<Room?> CreateRoomAsync(RoomToCreateDto model);
        Task<IReadOnlyList<Room>> GetAllRooms();
        Task<Room?> GetRoomById(int roomId);
    }
}
