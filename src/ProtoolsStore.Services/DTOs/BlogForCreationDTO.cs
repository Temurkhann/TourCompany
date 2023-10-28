using Microsoft.AspNetCore.Http;

namespace ProtoolsStore.Services.DTOs;

public class BlogForCreationDTO
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;

    public IFormFile? Image { get; set; }
}
