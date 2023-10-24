namespace ProtoolsStore.Services.ViewModels.Contacts;

public class ContactViewModel
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Message { get; set; } = null!;
}
