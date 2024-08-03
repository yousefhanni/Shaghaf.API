using Microsoft.AspNetCore.Mvc;
using Shaghaf.Core.Dtos;
using Shaghaf.Core.Services.Contract;
using System.Threading.Tasks;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]
public class BirthdayController : ControllerBase
{
    private readonly IBirthdayService _birthdayService;

    public BirthdayController(IBirthdayService birthdayService)
    {
        _birthdayService = birthdayService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateBirthday([FromBody] BirthdayDto birthdayDto)
    {
        var result = await _birthdayService.CreateBirthdayAsync(birthdayDto);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBirthday(int id, [FromBody] BirthdayDto birthdayDto)
    {
        birthdayDto.Id = id;
        await _birthdayService.UpdateBirthdayAsync(birthdayDto);
        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBirthdayById(int id)
    {
        var result = await _birthdayService.GetBirthdayByIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBirthdays()
    {
        var result = await _birthdayService.GetAllBirthdaysAsync();
        return Ok(result);
    }
}
