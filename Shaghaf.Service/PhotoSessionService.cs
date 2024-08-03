using AutoMapper;
using Shaghaf.Core.Dtos;
using Shaghaf.Core.Entities;
using Shaghaf.Core.Repositories.Contract;
using Shaghaf.Core.Services.Contract;
using Shaghaf.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shaghaf.Core.Entities.BirthdayEntity;

public class PhotoSessionService : IPhotoSessionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PhotoSessionService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<PhotoSessionDto> CreatePhotoSessionAsync(PhotoSessionDto photoSessionDto)
    {
        var photoSession = _mapper.Map<PhotoSession>(photoSessionDto);
        _unitOfWork.Repository<PhotoSession>().Add(photoSession);
        await _unitOfWork.CompleteAsync();
        return _mapper.Map<PhotoSessionDto>(photoSession);
    }

    public async Task UpdatePhotoSessionAsync(PhotoSessionDto photoSessionDto)
    {
        var photoSession = await _unitOfWork.Repository<PhotoSession>().GetByIdAsync(photoSessionDto.Id);
        if (photoSession == null)
        {
            throw new KeyNotFoundException("No photo session found matching the specified criteria.");
        }

        _mapper.Map(photoSessionDto, photoSession);
        _unitOfWork.Repository<PhotoSession>().Update(photoSession);
        await _unitOfWork.CompleteAsync();
    }

    public async Task<PhotoSessionDto?> GetPhotoSessionByIdAsync(int id)
    {
        var photoSession = await _unitOfWork.Repository<PhotoSession>().GetByIdAsync(id);
        return photoSession == null ? null : _mapper.Map<PhotoSessionDto>(photoSession);
    }

    public async Task<IReadOnlyList<PhotoSessionDto>> GetAllPhotoSessionsAsync()
    {
        var photoSessions = await _unitOfWork.Repository<PhotoSession>().GetAllAsync();
        return _mapper.Map<IReadOnlyList<PhotoSessionDto>>(photoSessions);
    }
}
