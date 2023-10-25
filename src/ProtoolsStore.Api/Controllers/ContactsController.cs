using Microsoft.AspNetCore.Mvc;
using ProtoolsStore.Domain.Entities;
using ProtoolsStore.Services.DTOs;
using ProtoolsStore.Services.Interfaces;
using ProtoolsStore.Services.ViewModels.Contacts;

namespace ProtoolsStore.Api.Controllers;

[ApiController]
[Route("[controller]")]
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

    [HttpPost]
    public async Task<ActionResult<ContactViewModel>> CreateAsync(ContactForCreationDTO dto)
    {
        return Ok(await _contactService.CreateAsync(dto));
    }

    [HttpGet("{Id:int}")]
    public async Task<ActionResult<ContactViewModel>> GetAsync([FromRoute]long Id)
    {
        return Ok(await _contactService.GetAsync(Id));
    }
    
    [HttpGet("/all")]
    public async Task<ActionResult<IEnumerable<ContactViewModel>>> GetAllAsync()
    {
        return Ok(await _contactService.GetAllAsync());
    }
}
