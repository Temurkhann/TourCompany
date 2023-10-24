namespace ProtoolsStore.Services.ViewModels.Tours;

public class TourViewModel
{
    public long Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Price { get; set; } = null!;
    public string ImagePath { get; set; } = null!;
    public int Stars { get; set; } = 5;
}
