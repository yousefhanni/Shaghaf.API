using AutoMapper;
using Shaghaf.Core;
using Shaghaf.Core.Dtos;
using Shaghaf.Core.Entities.BirthdayEntity;
using Shaghaf.Core.Repositories.Contract;
using Shaghaf.Core.Services.Contract;
using System.Collections.Generic;
using System.Threading.Tasks;

public class BirthdayService : IBirthdayService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BirthdayService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BirthdayDto> CreateBirthdayAsync(BirthdayToCreateDto birthdayToCreateDto)
    {
        var birthday = _mapper.Map<Birthday>(birthdayToCreateDto);
        _unitOfWork.Repository<Birthday>().AddAsync(birthday);
        await _unitOfWork.CompleteAsync();
        return _mapper.Map<BirthdayDto>(birthday);
    }

    public async Task UpdateBirthdayAsync(BirthdayDto birthdayDto)
    {
        var birthday = await _unitOfWork.Repository<Birthday>().GetByIdAsync(birthdayDto.Id);
        if (birthday == null)
        {
            throw new KeyNotFoundException("No birthday found matching the specified criteria.");
        }

        _mapper.Map(birthdayDto, birthday);
        _unitOfWork.Repository<Birthday>().Update(birthday);
        await _unitOfWork.CompleteAsync();
    }

    public async Task<BirthdayDto?> GetBirthdayByIdAsync(int id)
    {
        var spec = new BirthdayWithDetailsSpec(id);
        var birthday = await _unitOfWork.Repository<Birthday>().GetByIdWithSpecAsync(spec);
        return birthday == null ? null : _mapper.Map<BirthdayDto>(birthday);
    }

    public async Task<IReadOnlyList<BirthdayDto>> GetAllBirthdaysAsync()
    {
        var spec = new BirthdayWithDetailsSpec();
        var birthdays = await _unitOfWork.Repository<Birthday>().GetAllWithSpecAsync(spec);
        return _mapper.Map<IReadOnlyList<BirthdayDto>>(birthdays);
    }
}
