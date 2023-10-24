namespace ProtoolsStore.Services.DTOs;

public class OrderForCreationDTO
{
    public int TourId { get; set; }
    public string FullName { get; set; } = null!;
    public string Phone { get; set; } = null!;
}
