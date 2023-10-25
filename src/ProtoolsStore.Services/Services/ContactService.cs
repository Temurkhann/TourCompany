using AutoMapper;
using ProtoolsStore.Data.IRepositories;
using ProtoolsStore.Domain.Entities;
using ProtoolsStore.Services.DTOs;
using ProtoolsStore.Services.Interfaces;
using ProtoolsStore.Services.ViewModels.Contacts;

namespace ProtoolsStore.Services.Services;

public class ContactService : IContactService
{
    private readonly IRepository<Contact> _repository;
    private readonly IMapper _mapper;

    public ContactService(IRepository<Contact> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ContactViewModel> CreateAsync(ContactForCreationDTO dto)
    {
        var mappedContact = _mapper.Map<Contact>(dto);

        var result = await _repository.AddAsync(
            mappedContact, true, default);

        return _mapper.Map<ContactViewModel>(result);
    }

    public async Task<ContactViewModel> GetAsync(long id)
    {
        return _mapper.Map<ContactViewModel>(
            await _repository.GetAsync(x => x.Id == id));
    }

    public async Task<IEnumerable<ContactViewModel>> GetAllAsync()
    {
        return await Task.FromResult(_mapper.Map<IEnumerable<ContactViewModel>>(
            _repository.GetAll().AsEnumerable()));
    }
}