using Microsoft.AspNetCore.Http;

namespace ProtoolsStore.Services.DTOs;

public class BlogForCreationDTO
{
    public string TitleUz { get; set; } = null!;
    public string TitleRu { get; set; } = null!;
    public string TitleEn { get; set; } = null!;
    
    public string DescriptionUz { get; set; } = null!;
    public string DescriptionRu { get; set; } = null!;
    public string DescriptionEn { get; set; } = null!;

    public int AttachmentId { get; set; }
    public IFormFile Attachment { get; set; } = null!;
}
