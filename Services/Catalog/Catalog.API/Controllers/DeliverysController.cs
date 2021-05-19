using AutoMapper;
using Catalog.Application.Deliverys.Commands.AddDelivery;
using Catalog.Application.Deliverys.Commands.DeleteDelivery;
using Catalog.Application.Deliverys.Commands.UpdateDelivery;
using Catalog.Application.Deliverys.Queries.GetAllDeliverys;
using Catalog.Application.Deliverys.Queries.GetDeliveryById;
using Catalog.Application.DTO;
using Catalog.Application.Interfaces;
using Catalog.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeliverysController : ControllerBase
    {
        private readonly IMediator _meadiator;
        public DeliverysController(IMediator meadiator)
        {
            _meadiator = meadiator;
        }

        #region DeliverysAPI
        [HttpGet]
        public async Task<IActionResult> GetAllDeliverys() //IEnumerable<Delivery>
        {
            var query = new GetAllDeliverysQuery();
            var result = await _meadiator.Send(query);
            return Ok(result);
            //var res = await _deliveryService.GetAllDeliverysAysnc();
            //var resDTO = _mapper.Map<IEnumerable<DeliveryDTO>>(res);
            //return Ok(resDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeliveryByIdAsync(int id) //Delivery
        {
            var query = new GetDeliveryByIdQuery(id);
            var result = await _meadiator.Send(query);
            return result != null ? (IActionResult) Ok(result) : NotFound(result);
            //var res = await _deliveryService.GetDeliveryByIdAysnc(id);
            //if (res == null)
            //{
            //    return NotFound(res);
            //}
            //var resDTO = _mapper.Map<DeliveryDTO>(res);
            //return Ok(resDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddDeliveryAsync([FromBody] DeliveryDTO deliveryDTO)
        {
            var query = new AddDeliveryCommand(deliveryDTO);
            var result = await _meadiator.Send(query);
            return result == true ? (IActionResult)Ok(result) : BadRequest(result);
            //var delivery = _mapper.Map<Delivery>(deliveryDTO);
            //var res = await _deliveryService.AddDeliveryAysnc(delivery);
            //return res == true ? (IActionResult) Ok(res) : BadRequest(res);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDeliveryAsync([FromBody] DeliveryDTO deliveryDTO)
        {
            var query = new UpdateDeliveryCommand(deliveryDTO);
            var result = await _meadiator.Send(query);
            return result == true ? (IActionResult)Ok(result) : BadRequest(result);
            //var delivery = _mapper.Map<Delivery>(deliveryDTO);
            //var res = await _deliveryService.UpdateDeliveryAysnc(delivery);
            //return res == true ? (IActionResult) Ok(res) : BadRequest(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeliveryAsync(int id)
        {
            var query = new DeleteDeliveryCommand(id);
            var result = await _meadiator.Send(query);
            return result == true ? (IActionResult)Ok(result) : BadRequest(result);
            //var res = await _deliveryService.DeleteDeliveryAysnc(id);
            //return res == true ? (IActionResult)Ok(res) : BadRequest(res);
        }
        #endregion
    }
}
