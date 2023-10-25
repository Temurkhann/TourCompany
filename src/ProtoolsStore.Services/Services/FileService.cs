using Microsoft.AspNetCore.Http;
using ProtoolsStore.Data.IRepositories;
using ProtoolsStore.Domain.Entities;
using ProtoolsStore.Services.Helpers;
using ProtoolsStore.Services.Interfaces;

namespace ProtoolsStore.Services.Services;

public class FileService : IFileService
{
    private readonly IRepository<Attachment> _repository;

    public FileService(IRepository<Attachment> repository)
    {
        _repository = repository;
    }
    
    public async Task<Attachment> CreateAsync(IFormFile file)
    {
        var result = await FileHelper.SaveAsync(file, false);

        var res = await _repository.AddAsync(
            new()
            {
                Name = result.fileName,
                Path = result.filePath
            }) ?? new();

        await _repository.SaveChangesAsync();

        return res;
    }

    public Task RemoveAsync(string filePath)
    {
        FileHelper.Remove(filePath);

        return Task.CompletedTask;
    }
}