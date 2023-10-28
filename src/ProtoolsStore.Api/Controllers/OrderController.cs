using Microsoft.AspNetCore.Mvc;
using ProtoolsStore.Domain.Configurations;
using ProtoolsStore.Services.DTOs;
using ProtoolsStore.Services.Interfaces;
using ProtoolsStore.Services.ViewModels.Order;
using System.Formats.Asn1;

namespace ProtoolsStore.Api.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            this._orderService = orderService;
        }

        /// <summary>
        /// (Hamma userlar uchun) yangi order yaratish
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<OrderViewModel>> CreateAsync([FromForm] OrderForCreationDTO dto)
            => Ok(await  _orderService.CreateAsync(dto));

        /// <summary>
        /// (Admin uchun) barcha orderlar ro'yhatini olish uchun
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<OrderViewModel>>> GetAll()
            => Ok(await _orderService.GetAllAsync());

        /// <summary>
        /// (Admin uchun) id bilan orderlardan birini tanlab olish
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<OrderViewModel>> Get([FromRoute] long id)
            => Ok (await _orderService.GetAsync(id));
    }
}
