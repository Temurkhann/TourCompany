using ProtoolsStore.Services.DTOs;
using ProtoolsStore.Services.ViewModels.Order;

namespace ProtoolsStore.Services.Interfaces;

public interface IOrderService
{
    Task<OrderViewModel> CreateAsync(OrderForCreationDTO dto);
    Task<OrderViewModel> GetAsync(long id);
    Task<IEnumerable<OrderViewModel>> GetAllAsync();
}