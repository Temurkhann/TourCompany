using ProtoolsStore.Services.DTOs;
using ProtoolsStore.Services.ViewModels.Tours;

namespace ProtoolsStore.Services.Interfaces;

public interface ITourService
{
    Task<TourViewModel> CreateAsync(TourForCreationDTO dto);
    Task<TourViewModel> GetAsync(long id);
    Task<IEnumerable<TourViewModel>> GetAllAsync();
}