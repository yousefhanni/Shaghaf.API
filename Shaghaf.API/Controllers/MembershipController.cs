using Microsoft.AspNetCore.Mvc;
using Shaghaf.Core.Dtos;
using Shaghaf.Core.Services.Contract;
using System.Threading.Tasks;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]
public class MembershipController : ControllerBase
{
    private readonly IMembershipService _membershipService;

    public MembershipController(IMembershipService membershipService)
    {
        _membershipService = membershipService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateMembership([FromBody] MembershipDto membershipDto)
    {
        var result = await _membershipService.CreateMembershipAsync(membershipDto);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMembership(int id, [FromBody] MembershipDto membershipDto)
    {
        membershipDto.Id = id;
        await _membershipService.UpdateMembershipAsync(membershipDto);
        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMembershipById(int id)
    {
        var result = await _membershipService.GetMembershipByIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllMemberships()
    {
        var result = await _membershipService.GetAllMembershipsAsync();
        return Ok(result);
    }
}
