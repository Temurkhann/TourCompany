using Microsoft.AspNetCore.Mvc;
using ProtoolsStore.Domain.Configurations;
using ProtoolsStore.Services.DTOs;
using ProtoolsStore.Services.Interfaces;

namespace ProtoolsStore.Api.Controllers
{
    public class BlogController : ControllerBase
    {
        private readonly IBlogService blogService;

        public BlogController(IBlogService blogService)
        {
            this.blogService = blogService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] BlogForCreationDTO blogForCreationDTO)
            => Ok(await blogService.CreateAsync(blogForCreationDTO));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] long id)
            => Ok(await blogService.GetAsync(id));

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationParams @params)
            => Ok(await blogService.GetAllAsync());
    }
}
