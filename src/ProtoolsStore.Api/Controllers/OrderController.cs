using Microsoft.AspNetCore.Mvc;
using ProtoolsStore.Domain.Configurations;
using ProtoolsStore.Services.DTOs;
using ProtoolsStore.Services.Interfaces;
using ProtoolsStore.Services.ViewModels.Order;
using System.Formats.Asn1;

namespace ProtoolsStore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;
        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpPost]
        public async Task<ActionResult<OrderViewModel>> CreateAsync([FromForm] OrderForCreationDTO dto)
            => Ok(await  orderService.CreateAsync(dto));

        [HttpGet("{all}")]
        public async Task<ActionResult<IEnumerable<OrderViewModel>>> GetAll()
            => Ok(await orderService.GetAllAsync());

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<OrderViewModel>> Get([FromRoute] long id)
            => Ok (await orderService.GetAsync(id));
    }
}
