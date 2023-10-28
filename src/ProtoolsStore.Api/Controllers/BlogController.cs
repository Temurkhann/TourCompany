using Microsoft.AspNetCore.Mvc;
using ProtoolsStore.Domain.Configurations;
using ProtoolsStore.Services.DTOs;
using ProtoolsStore.Services.Interfaces;
using ProtoolsStore.Services.ViewModels.Blogs;

namespace ProtoolsStore.Api.Controllers;

[ApiController]
[Route("blog-posts")]
public class BlogController : ControllerBase
{
    private readonly IBlogService _blogService;

    public BlogController(IBlogService blogService)
    {
        this._blogService = blogService;
    }
    
    /// <summary>
    /// (Admin uchun) yangi blog uchun post yaratish 
    /// </summary>
    /// <param name="blogForCreationDTO"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<BlogViewModel>> CreateAsync([FromForm] BlogForCreationDTO blogForCreationDTO)
        => Ok(await _blogService.CreateAsync(blogForCreationDTO));

    /// <summary>
    /// (Hamma userlar uchun) postlardan birini id bilan olish
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:long}")]
    public async Task<ActionResult<BlogViewModel>> GetAsync([FromRoute] long id)
        => Ok(await _blogService.GetAsync(id));

    /// <summary>
    /// (Hamma userlar uchun) barcha postlarni olish uchun
    /// </summary>
    /// <returns></returns>
    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<BlogViewModel>>> GetAll()
        => Ok(await _blogService.GetAllAsync());
}
