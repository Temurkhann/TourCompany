using ProtoolsStore.Data.IRepositories;
using ProtoolsStore.Services.DTOs;
using ProtoolsStore.Services.Interfaces;
using ProtoolsStore.Services.ViewModels.Blogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoolsStore.Services.Services
{
    public class BlogService : IBlogService
    {
        private readonly IRepository
        public Task<BlogViewModel> CreateAsync(BlogForCreationDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BlogViewModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BlogViewModel> GetAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
