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
        private readonly IRepository<Order> _repository;
        private readonly IRepository<Tour> _tourRepository;
        private readonly IMapper _mapper;
        public OrderService(
            IRepository<Order> repository, 
            IMapper mapper, 
            IRepository<Tour> tourRepository)
        {
            this._repository = repository;
            this._mapper = mapper;
            _tourRepository = tourRepository;
        }
        public async Task<OrderViewModel> CreateAsync(OrderForCreationDTO dto)
        {
            var existTour = await _tourRepository.GetAsync(x => x.Id == dto.TourId);
            if (existTour is null)
                throw new HttpException("Given tour type not exist in database", 400);

            var mappedOrder = _mapper.Map<Order>(dto);
            mappedOrder.Tour = existTour;
            mappedOrder.Create();
            
            var order = await _repository.AddAsync(mappedOrder);
            await _repository.SaveChangesAsync();
            
            return _mapper.Map<OrderViewModel>(order);
        }

        public async Task<IEnumerable<OrderViewModel>> GetAllAsync()
        {
            return await Task.FromResult(_mapper.Map<IEnumerable<OrderViewModel>>(
            _repository.GetAll(null, new []{ "Tour" }).AsEnumerable()));
        }

        public async Task<OrderViewModel> GetAsync(long id)
        {
            var existedOrder = await _repository.GetAsync(
                x => x.Id == id, new[] { "Tour" });
            if (existedOrder is null)
                throw new HttpException("Order not found in database", 404);
            
            return _mapper.Map<OrderViewModel>(existedOrder);
        }
    }
}
