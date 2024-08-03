using Shaghaf.Core.Dtos;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Shaghaf.Core.Services.Contract
{
    public interface IMembershipService
    {
        Task<MembershipDto> CreateMembershipAsync(MembershipDto membershipDto);
        Task UpdateMembershipAsync(MembershipDto membershipDto);
        Task<MembershipDto?> GetMembershipByIdAsync(int id);
        Task<IReadOnlyList<MembershipDto>> GetAllMembershipsAsync();
    }
}
