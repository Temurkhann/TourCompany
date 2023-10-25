using Microsoft.AspNetCore.Mvc;
using ProtoolsStore.Domain.Configurations;
using ProtoolsStore.Services.DTOs;
using ProtoolsStore.Services.Interfaces;
using ProtoolsStore.Services.ViewModels.Blogs;

namespace ProtoolsStore.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BlogController : ControllerBase
{
    private readonly IBlogService blogService;

    public BlogController(IBlogService blogService)
    {
        this.blogService = blogService;
    }

    [HttpPost]
    public async Task<ActionResult<BlogViewModel>> CreateAsync([FromForm] BlogForCreationDTO blogForCreationDTO)
        => Ok(await blogService.CreateAsync(blogForCreationDTO));

    [HttpGet("{id:int}")]
    public async Task<ActionResult<BlogViewModel>> GetAsync([FromRoute] long id)
        => Ok(await blogService.GetAsync(id));

    [HttpGet("{all}")]
    public async Task<ActionResult<IEnumerable<BlogViewModel>>> GetAll()
        => Ok(await blogService.GetAllAsync());
}
