using Shaghaf.Core.Dtos;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Shaghaf.Core.Services.Contract
{
    public interface IPhotoSessionService
    {
        Task<PhotoSessionDto> CreatePhotoSessionAsync(PhotoSessionDto photoSessionDto);
        Task UpdatePhotoSessionAsync(PhotoSessionDto photoSessionDto);
        Task<PhotoSessionDto?> GetPhotoSessionByIdAsync(int id);
        Task<IReadOnlyList<PhotoSessionDto>> GetAllPhotoSessionsAsync();
    }
}
