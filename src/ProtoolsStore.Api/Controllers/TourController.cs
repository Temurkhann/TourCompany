using Microsoft.AspNetCore.Mvc;
using ProtoolsStore.Services.DTOs;
using ProtoolsStore.Services.Interfaces;
using ProtoolsStore.Services.ViewModels.Tours;

namespace ProtoolsStore.Api.Controllers;

[ApiController]
[Route("tour-package")]
public class TourController : ControllerBase
{
    private readonly ITourService _tourService;

    public TourController(ITourService tourService)
    {
        _tourService = tourService;
    }
    
    
    /// <summary>
    /// (Admin uchun) Tour Paketlar yaratish
    /// </summary>
    /// <param name="dto"> <see cref="TourForCreationDTO"/></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<TourViewModel>> CreateAsync([FromForm]TourForCreationDTO dto)
    {
        return Ok(await _tourService.CreateAsync(dto));
    }

    /// <summary>
    /// (Hamma userlar uchun) Tour Paketlarning birini id bilan olish
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:long}")]
    public async Task<ActionResult<TourViewModel>> GetAsync([FromRoute]long id)
    {
        return Ok(await _tourService.GetAsync(id));
    }
    
    /// <summary>
    /// (Hamma userlar uchun) Tour Paketlarni olish
    /// </summary>
    /// <returns></returns>
    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<TourViewModel>>> GetAllAsync()
    {
        return Ok(await _tourService.GetAllAsync());
    }
}