using Microsoft.AspNetCore.Mvc;
using Shaghaf.Core.Dtos;
using Shaghaf.Core.Services.Contract;
using System.Threading.Tasks;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]
public class PhotoSessionController : ControllerBase
{
    private readonly IPhotoSessionService _photoSessionService;

    public PhotoSessionController(IPhotoSessionService photoSessionService)
    {
        _photoSessionService = photoSessionService;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePhotoSession([FromBody] PhotoSessionDto photoSessionDto)
    {
        var result = await _photoSessionService.CreatePhotoSessionAsync(photoSessionDto);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePhotoSession(int id, [FromBody] PhotoSessionDto photoSessionDto)
    {
        photoSessionDto.Id = id;
        await _photoSessionService.UpdatePhotoSessionAsync(photoSessionDto);
        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPhotoSessionById(int id)
    {
        var result = await _photoSessionService.GetPhotoSessionByIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPhotoSessions()
    {
        var result = await _photoSessionService.GetAllPhotoSessionsAsync();
        return Ok(result);
    }
}
