using ProtoolsStore.Services.ViewModels.Tours;

namespace ProtoolsStore.Services.ViewModels.Order;

public class OrderViewModel
{
    public long Id { get; set; }
    public TourViewModel Tour { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string Phone { get; set; } = null!;
}
