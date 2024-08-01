using Microsoft.AspNetCore.Http.HttpResults;
using Shaghaf.Core;
using Shaghaf.Core.Dtos;
using Shaghaf.Core.Entities.HomeEntities;
using Shaghaf.Core.Entities.RoomEntities;
using Shaghaf.Core.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Shaghaf.Service
{
    public class RoomService : IRoomService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoomService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Room?> CreateRoomAsync(RoomToCreateDto model)
        {
            var roomRepo = _unitOfWork.Repository<Room>();
            var room = new Room
            {
                Offer = model.Offer,
                Rate  = model.Rate,
                Name = model.Name,
                Seat = model.Seat,
                Description = model.Description,
                Location = model.Location,
                Date = model.Date,
                Price = model.Price
                //Plan = model.Plan,
                //Type = model.Type
            };
            roomRepo.Add(room);
            var result = await _unitOfWork.CompleteAsync();
            if (result <= 0) return null;

            return room;


        }

        public async Task<IReadOnlyList<Room>> GetAllRooms()
        {
            var roomRepo = _unitOfWork.Repository<Room>();

            var rooms = await roomRepo.GetAllAsync();

            var roomslist = rooms.ToList();

            return roomslist;
        }

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
