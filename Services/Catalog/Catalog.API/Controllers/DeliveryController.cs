using AutoMapper;
using Catalog.API.DTO;
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
        private IDeliveryService _deliveryService;
        private readonly IMapper _mapper;
        public DeliveryController(IDeliveryService deliveryService, IMapper mapper)
        {
            _deliveryService = deliveryService;
            _mapper = mapper;
        }

        #region DeliveryAPI
        [HttpGet]
        public async Task<IActionResult> GetAllDeliverys() //IEnumerable<Delivery>
        {
            var res = await _deliveryService.GetAllDeliverysAysnc();
            var resDTO = _mapper.Map<IEnumerable<DeliveryDTO>>(res);
            return Ok(resDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeliveryByIdAsync(int id) //Delivery
        {
            var res = await _deliveryService.GetDeliveryByIdAysnc(id);
            if (res == null)
            {
                return NotFound(res);
            }
            var resDTO = _mapper.Map<IEnumerable<DeliveryDTO>>(res);
            return Ok(resDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddDeliveryAsync([FromBody] DeliveryDTO deliveryDTO)
        {
            var delivery = _mapper.Map<Delivery>(deliveryDTO);
            var res = await _deliveryService.AddDeliveryAysnc(delivery);
            if (!res)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDeliveryAsync([FromBody] DeliveryDTO deliveryDTO)
        {
            var delivery = _mapper.Map<Delivery>(deliveryDTO);
            var res = await _deliveryService.UpdateDeliveryAysnc(delivery);
            if (!res)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeliveryAsync(int id)
        {
            var res = await _deliveryService.DeleteDeliveryAysnc(id);
            if (!res)
            {
                return NotFound(res);
            }
            return Ok(res);
        }
        #endregion
    }
}
