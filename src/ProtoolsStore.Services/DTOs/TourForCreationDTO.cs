using Microsoft.AspNetCore.Http;

namespace ProtoolsStore.Services.DTOs;

public class TourForCreationDTO
{
    public string Title { get; set; } = null!;
    public string Location { get; set; } = null!;

    public string Description { get; set; } = null!;
    
    public string Price { get; set; }   
    public IFormFile Image { get; set; } = null!;
}
