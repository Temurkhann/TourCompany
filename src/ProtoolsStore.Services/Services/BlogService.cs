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
        private readonly IRepository<Blog> repository;
        private readonly IMapper mapper;
        private readonly FileService fileService;

        public BlogService(IRepository<Blog> repository, FileService fileService, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<BlogViewModel> CreateAsync(BlogForCreationDTO dto)
        {
            Attachment file = default!;
            if (dto.Attachment is not null)
                file = await fileService.CreateAsync(dto.Attachment);

            var mappedTour = mapper.Map<Blog>(dto);
            mappedTour.Attachment = file;
            mappedTour.AttachmentId = file.Id;

            var res = await repository.AddAsync(mappedTour);

            return mapper.Map<BlogViewModel>(res);
        }

        public async Task<IEnumerable<BlogViewModel>> GetAllAsync()
        {
            return await Task.FromResult(mapper.Map<IEnumerable<BlogViewModel>>(
            repository.GetAll().AsEnumerable()));
        }

        public async Task<BlogViewModel> GetAsync(long id)
        {
            var blog = await repository.GetAsync(expression => expression.Id == id);
            if (blog != null)
                throw new HttpException("Blog not found");

            return mapper.Map<BlogViewModel>(blog);
        }
    }
}
