using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ordering.BLL.Interfaces.IUnitOfWork;
using Ordering.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oredering.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[Authorize]
    public class OrderingController : ControllerBase
    {
        private readonly IOrderingUnitOfWork _unitOfWork;

        public OrderingController(IOrderingUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region APIs
        // GET: /Ordering Get all Orders
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _unitOfWork.orderService.GetAllOrders());
        }

        // GET: /Ordering/{id} Get Order by id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _unitOfWork.orderService.GetOrder(id));
        }

        // POST: /Ordering Add new Order
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Orders order)
        {
            return Ok(await _unitOfWork.orderService.AddOrder(order));
        }

        // PUT: /Ordering Update existing Order
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Orders order)
        {
            return Ok(await _unitOfWork.orderService.UpdateOrder(order));
        }

        // DELETE: /Ordering/{id} Delete existing Order
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _unitOfWork.orderService.DeleteOrder(id));
        }
        #endregion
    }
}
