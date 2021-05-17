using Catalog.Application.Interfaces;
using Catalog.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeliveryController : ControllerBase
    {
        private IDeliveryService _deliveryService { get; }
        public DeliveryController(IDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
        }

        #region DeliveryAPI
        [HttpGet]
        public async Task<IActionResult> GetAllDeliverys() //IEnumerable<Delivery>
        {
            return Ok(await _deliveryService.GetAllDeliverysAysnc());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeliveryByIdAsync(int id) //Delivery
        {
            return Ok(await _deliveryService.GetDeliveryByIdAysnc(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddDeliveryAsync([FromBody] Delivery item)
        {
            var res = await _deliveryService.AddDeliveryAysnc(item);
            if (!res)
            {
                return BadRequest(res);
            }
            else
            {
                return Ok(res);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDeliveryAsync([FromBody] Delivery item)
        {
            var res = await _deliveryService.UpdateDeliveryAysnc(item);
            if (!res)
            {
                return BadRequest(res);
            }
            else
            {
                return Ok(res);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeliveryAsync(int id)
        {
            var res = await _deliveryService.DeleteDeliveryAysnc(id);
            if (!res)
            {
                return BadRequest(res);
            }
            else
            {
                return Ok(res);
            }
        }
        #endregion
    }
}
