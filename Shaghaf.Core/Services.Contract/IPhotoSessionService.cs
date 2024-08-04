﻿using Shaghaf.Core.Dtos;

namespace Shaghaf.Core.Services.Contract
{
    public interface IPhotoSessionService
    {
        Task<PhotoSessionDto> CreatePhotoSessionAsync(PhotoSessionToCreateDto photoSessionDto);
        Task UpdatePhotoSessionAsync(PhotoSessionDto photoSessionDto);
        Task<PhotoSessionDto?> GetPhotoSessionByIdAsync(int id);
        Task<IReadOnlyList<PhotoSessionDto>> GetAllPhotoSessionsAsync();
    }
}
