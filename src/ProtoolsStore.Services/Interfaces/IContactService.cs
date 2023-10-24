using ProtoolsStore.Services.DTOs;
using ProtoolsStore.Services.ViewModels.Contacts;

namespace ProtoolsStore.Services.Interfaces;

public interface IContactService
{
    Task<ContactViewModel> CreateAsync(ContactForCreationDTO dto);
    Task<ContactViewModel> GetAsync(long id);
    Task<IEnumerable<ContactViewModel>> GetAllAsync();
}