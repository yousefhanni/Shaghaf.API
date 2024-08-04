using AutoMapper;
using Shaghaf.Core;
using Shaghaf.Core.Dtos;
using Shaghaf.Core.Entities;
using Shaghaf.Core.Entities.MembershipEntity;
using Shaghaf.Core.Repositories.Contract;
using Shaghaf.Core.Services.Contract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class MembershipService : IMembershipService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public MembershipService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<MembershipDto> CreateMembershipAsync(MembershipToCreateDto membershipDto)
    {
        var membership = _mapper.Map<Membership>(membershipDto);
        _unitOfWork.Repository<Membership>().Add(membership);
        await _unitOfWork.CompleteAsync();
        return _mapper.Map<MembershipDto>(membership);
    }

    public async Task UpdateMembershipAsync(MembershipDto membershipDto)
    {
        var membership = await _unitOfWork.Repository<Membership>().GetByIdAsync(membershipDto.Id);
        if (membership == null)
        {
            throw new KeyNotFoundException("No membership found matching the specified criteria.");
        }

        _mapper.Map(membershipDto, membership);
        _unitOfWork.Repository<Membership>().Update(membership);
        await _unitOfWork.CompleteAsync();
    }

    public async Task<MembershipDto?> GetMembershipByIdAsync(int id)
    {
        var membership = await _unitOfWork.Repository<Membership>().GetByIdAsync(id);
        return membership == null ? null : _mapper.Map<MembershipDto>(membership);
    }

    public async Task<IReadOnlyList<MembershipDto>> GetAllMembershipsAsync()
    {
        var memberships = await _unitOfWork.Repository<Membership>().GetAllAsync();
        return _mapper.Map<IReadOnlyList<MembershipDto>>(memberships);
    }
}
