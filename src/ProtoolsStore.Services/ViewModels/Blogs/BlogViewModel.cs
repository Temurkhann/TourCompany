namespace ProtoolsStore.Services.ViewModels.Blogs;

public class BlogViewModel
{
    public long Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string ImagePath { get; set; } = null!;
}
