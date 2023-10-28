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
        if (dto.Image is not null)
            file = await _fileService.CreateAsync(dto.Image);

        var mappedTour = _mapper.Map<Tour>(dto);
        mappedTour.Attachment = file;
        mappedTour.AttachmentId = file?.Id;
        mappedTour.Create();

        var res = await _repository.AddAsync(mappedTour);
        await _repository.SaveChangesAsync();
        return _mapper.Map<TourViewModel>(res);
    }

    public async Task<TourViewModel> GetAsync(long id)
    {
        var result = await _repository.GetAsync(
            x => x.Id == id, 
            new []{ "Attachment" });

        if (result is null)
            throw new HttpException("Tour type not found with given id", 404);

        return _mapper.Map<TourViewModel>(result);
    }

    public async Task<IEnumerable<TourViewModel>> GetAllAsync()
    {
        return await Task.FromResult(_mapper.Map<IEnumerable<TourViewModel>>(
            _repository.GetAll(null, new []{ "Attachment" })
                              .AsEnumerable()));
    }
}