using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ordering.API.DTO;
using Ordering.BLL.Interfaces.IServices;
using Ordering.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Oredering.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[Authorize]
    public class OrderingController : ControllerBase
    {
        private readonly IOrderingService _orderService;
        private readonly IMapper _mapper;

        public OrderingController(IOrderingService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        #region APIs
        // GET: /Ordering Get all Orders
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await _orderService.GetAllOrders();
            if (res == null)
            {
                return NotFound(res);
            }
            var resDTO = _mapper.Map<IEnumerable<OrdersDTO>>(res);
            return Ok(resDTO);
        }

        // GET: /Ordering/{id} Get Order by id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await _orderService.GetOrder(id);
            var resDTO = _mapper.Map<IEnumerable<OrdersDTO>>(res);
            return Ok(resDTO);
        }

        // POST: /Ordering Add new Order
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrdersDTO orderDTO)
        {
            var order = _mapper.Map<Orders>(orderDTO);
            var res = await _orderService.AddOrder(order);
            if (res == null)
            {
                return BadRequest(res);
            }
            var resDto = _mapper.Map<OrdersDTO>(res);
            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var loactionUri = baseUrl + "/Ordering/" + res.Id.ToString();
            return Created(loactionUri, resDto);
        }

        // PUT: /Ordering Update existing Order
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] OrdersDTO orderDTO)
        {
            var order = _mapper.Map<Orders>(orderDTO);
            var res = await _orderService.UpdateOrder(order);
            if (res == null)
            {
                return BadRequest(res);
            }
            var resDto = _mapper.Map<OrdersDTO>(res);
            return Ok(resDto);
        }

        // DELETE: /Ordering/{id} Delete existing Order
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _orderService.DeleteOrder(id);
            if (res == null)
            {
                return NotFound(res);
            }
            var resDTO = _mapper.Map<IEnumerable<OrdersDTO>>(res);
            return Ok(resDTO);
        }
        #endregion
    }
}
