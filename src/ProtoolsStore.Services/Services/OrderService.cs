using AutoMapper;
using ProtoolsStore.Data.IRepositories;
using ProtoolsStore.Data.Repositories;
using ProtoolsStore.Domain.Entities;
using ProtoolsStore.Services.DTOs;
using ProtoolsStore.Services.Interfaces;
using ProtoolsStore.Services.ViewModels.Order;
using ProtoolsStore.Services.ViewModels.Tours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoolsStore.Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> repository;
        private readonly IMapper mapper;
        public OrderService(IRepository<Order> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<OrderViewModel> CreateAsync(OrderForCreationDTO dto)
        {
            var exsistOrder = await repository.GetAsync(d=>d.TourId == dto.TourId);
            if (exsistOrder != null)
                throw new HttpException("Order already exsist");
            var order = await repository.AddAsync(mapper.Map<Order>(dto));
            return mapper.Map<OrderViewModel>(order);
        }

        public async Task<IEnumerable<OrderViewModel>> GetAllAsync()
        {
            return await Task.FromResult(mapper.Map<IEnumerable<OrderViewModel>>(
            repository.GetAll().AsEnumerable()));
        }

        public async Task<OrderViewModel> GetAsync(long id)
        {
            return mapper.Map<OrderViewModel>(
            await repository.GetAsync(x => x.Id == id));
        }
    }
}
