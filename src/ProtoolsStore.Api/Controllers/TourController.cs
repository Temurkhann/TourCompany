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
    /// Tur Paketlar yaratish
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost()]
    public async Task<ActionResult<TourViewModel>> CreateAsync([FromForm]TourForCreationDTO dto)
    {
        return Ok(await _tourService.CreateAsync(dto));
    }

    /// <summary>
    /// Tur Paketlarning birini id bilan olish
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    [HttpGet("{Id:long}")]
    public async Task<ActionResult<TourViewModel>> GetAsync([FromRoute]long Id)
    {
        return Ok(await _tourService.GetAsync(Id));
    }
    
    /// <summary>
    ///  Tur Paketlarni olish
    /// </summary>
    /// <returns></returns>
    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<TourViewModel>>> GetAllAsync()
    {
        return Ok(await _tourService.GetAllAsync());
    }
}