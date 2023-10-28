using AutoMapper;
using ProtoolsStore.Data.IRepositories;
using ProtoolsStore.Data.Repositories;
using ProtoolsStore.Domain.Entities;
using ProtoolsStore.Services.DTOs;
using ProtoolsStore.Services.Interfaces;
using ProtoolsStore.Services.ViewModels.Blogs;
using ProtoolsStore.Services.ViewModels.Tours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoolsStore.Services.Services
{
    public class BlogService : IBlogService
    {
        private readonly IRepository<Blog> _repository;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public BlogService(IRepository<Blog> repository, IFileService fileService, IMapper mapper)
        {
            this._fileService = fileService;
            this._repository = repository;
            this._mapper = mapper;
        }
        public async Task<BlogViewModel> CreateAsync(BlogForCreationDTO dto)
        {
            Attachment file = default!;
            if (dto.Image is not null)
                file = await _fileService.CreateAsync(dto.Image);

            var mappedTour = _mapper.Map<Blog>(dto);
            mappedTour.Attachment = file;
            mappedTour.AttachmentId = file?.Id;

            var res = await _repository.AddAsync(mappedTour); 
            await _repository.SaveChangesAsync();
            return _mapper.Map<BlogViewModel>(res);
        }

        public async Task<IEnumerable<BlogViewModel>> GetAllAsync()
        {
            return await Task.FromResult(_mapper.Map<IEnumerable<BlogViewModel>>(
            _repository.GetAll().AsEnumerable()));
        }

        public async Task<BlogViewModel> GetAsync(long id)
        {
            var existedBlog = await _repository.GetAsync(b => b.Id == id);
            if (existedBlog == null)
                throw new HttpException("Blog not found in database", 404);

            return _mapper.Map<BlogViewModel>(existedBlog);
        }
    }
}
