using AutoMapper;
using ProtoolsStore.Data.IRepositories;
using ProtoolsStore.Domain.Entities;
using ProtoolsStore.Services.DTOs;
using ProtoolsStore.Services.Interfaces;
using ProtoolsStore.Services.ViewModels.Tours;

namespace ProtoolsStore.Services.Services;

public class TourService : ITourService
{
    private readonly IRepository<Tour> _repository;
    private readonly IMapper _mapper;
    private readonly IFileService _fileService;

    public TourService(
        IRepository<Tour> repository, 
        IMapper mapper, 
        IFileService fileService)
    {
        _repository = repository;
        _mapper = mapper;
        _fileService = fileService;
    }

    public async Task<TourViewModel> CreateAsync(TourForCreationDTO dto)
    {
        Attachment file = default!;
        if (dto.Attachment is not null)
            file = await _fileService.CreateAsync(dto.Attachment);

        var mappedTour = _mapper.Map<Tour>(dto);
        mappedTour.Attachment = file;
        mappedTour.AttachmentId = file.Id;

        var res = await _repository.AddAsync(mappedTour);

        return _mapper.Map<TourViewModel>(res);
    }

    public async Task<TourViewModel> GetAsync(long id)
    {
        return _mapper.Map<TourViewModel>(
            await _repository.GetAsync(x => x.Id == id));
    }

    public async Task<IEnumerable<TourViewModel>> GetAllAsync()
    {
        return await Task.FromResult(_mapper.Map<IEnumerable<TourViewModel>>(
            _repository.GetAll().AsEnumerable()));
    }
}