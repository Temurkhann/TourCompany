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
        mappedContact.Create();
        var result = await _repository.AddAsync(
            mappedContact);
        await _repository.SaveChangesAsync();
        return _mapper.Map<ContactViewModel>(result);
    }

    public async Task<ContactViewModel> GetAsync(long id)
    {
        var result = await _repository.GetAsync(x => x.Id == id);

        if (result is null)
            throw new HttpException("Contact not found with given id", 404);

        return _mapper.Map<ContactViewModel>(result);
    }

    public async Task<IEnumerable<ContactViewModel>> GetAllAsync()
    {
        return await Task.FromResult(_mapper.Map<IEnumerable<ContactViewModel>>(
            _repository.GetAll().AsEnumerable()));
    }
}