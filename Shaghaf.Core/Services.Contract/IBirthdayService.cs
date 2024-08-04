using Shaghaf.Core.Dtos;

namespace Shaghaf.Core.Services.Contract
{
    public interface IBirthdayService
    {
        Task<BirthdayDto> CreateBirthdayAsync(BirthdayToCreateDto birthdayToCreateDto);
        Task UpdateBirthdayAsync(BirthdayDto birthdayDto);
        Task<BirthdayDto?> GetBirthdayByIdAsync(int id);
        Task<IReadOnlyList<BirthdayDto>> GetAllBirthdaysAsync();
    }
}
