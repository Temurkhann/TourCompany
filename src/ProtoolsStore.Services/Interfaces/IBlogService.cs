using ProtoolsStore.Services.DTOs;
using ProtoolsStore.Services.ViewModels.Blogs;

namespace ProtoolsStore.Services.Interfaces;

public interface IBlogService
{
    Task<BlogViewModel> CreateAsync(BlogForCreationDTO dto);
    Task<BlogViewModel> GetAsync(long id);
    Task<IEnumerable<BlogViewModel>> GetAllAsync();
}