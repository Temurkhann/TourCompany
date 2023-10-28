using Microsoft.AspNetCore.Mvc;
using ProtoolsStore.Services.DTOs;
using ProtoolsStore.Services.Interfaces;
using ProtoolsStore.Services.ViewModels.Contacts;

namespace ProtoolsStore.Api.Controllers;

[ApiController]
[Route("contacts")]
public class ContactsController : ControllerBase
{
    private readonly ILogger<ContactsController> _logger;
    private readonly IContactService _contactService;   
    public ContactsController(
        ILogger<ContactsController> logger, 
        IContactService contactService)
    {
        _logger = logger;
        _contactService = contactService;
    }

    /// <summary>
    /// (Hamma userlar uchun) Companiya bilan aloqa bo'limi so'rovini yaratish
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<ContactViewModel>> CreateAsync(ContactForCreationDTO dto)
    {
        return Ok(await _contactService.CreateAsync(dto));
    }

    /// <summary>
    /// (Admin uchun) Companiya bilan aloqa bo'limi so'rovining birini id bilan olish
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:long}")]
    public async Task<ActionResult<ContactViewModel>> GetAsync([FromRoute]long id)
    {
        return Ok(await _contactService.GetAsync(id));
    }
    
    /// <summary>
    /// (Admin uchun) Companiya bilan aloqa bo'limi so'rovlarini olish
    /// </summary>
    /// <returns></returns>
    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<ContactViewModel>>> GetAllAsync()
    {
        return Ok(await _contactService.GetAllAsync());
    }
}
