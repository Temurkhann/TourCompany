using Microsoft.AspNetCore.Http;
using ProtoolsStore.Domain.Entities;

namespace ProtoolsStore.Services.Interfaces;

public interface IFileService
{
    Task<Attachment> CreateAsync(IFormFile file);
    Task RemoveAsync(string fileName);
}