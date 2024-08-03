using Shaghaf.Core.Dtos;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Shaghaf.Core.Services.Contract
{
    public interface IBirthdayService
    {
        Task<BirthdayDto> CreateBirthdayAsync(BirthdayDto birthdayDto);
        Task UpdateBirthdayAsync(BirthdayDto birthdayDto);
        Task<BirthdayDto?> GetBirthdayByIdAsync(int id);
        Task<IReadOnlyList<BirthdayDto>> GetAllBirthdaysAsync();
    }
}
