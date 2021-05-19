using AutoMapper;
using Catalog.Application.DTO;
using Catalog.Application.Interfaces;
using Catalog.Application.Items.Commands.AddItem;
using Catalog.Application.Items.Commands.DeleteItem;
using Catalog.Application.Items.Commands.UpdateItem;
using Catalog.Application.Items.Queries.GetAllItems;
using Catalog.Application.Items.Queries.GetItemById;
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
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        private readonly IMapper _mapper;
        private readonly IMediator _meadiator;
        public ItemController(IItemService itemService, IMapper mapper, IMediator meadiator)
        {
            _itemService = itemService;
            _mapper = mapper;
            _meadiator = meadiator;
        }

        #region ItemsAPI
        [HttpGet]
        public async Task<IActionResult> GetAllItems() //IEnumerable<Item>
        {
            var query = new GetAllItemsQuery();
            var result = await _meadiator.Send(query);
            return Ok(result);
            //var res = await _itemService.GetAllItemsAysnc();
            //var resDTO = _mapper.Map<IEnumerable<ItemDTO>>(res);
            //return Ok(resDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemByIdAsync(int id)
        {
            var query = new GetItemByIdQuery(id);
            var result = await _meadiator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound(result);
            //var res = await _itemService.GetItemByIdAysnc(id);
            //return res != null? (IActionResult) Ok(_mapper.Map<ItemDTO>(res)) : NotFound(res);
        }

        [HttpPost]
        public async Task<IActionResult> AddItemAsync([FromBody] ItemDTO itemDTO)
        {
            var query = new AddItemCommand(itemDTO);
            var result = await _meadiator.Send(query);
            return result == true ? (IActionResult)Ok(result) : BadRequest(result);
            //var item = _mapper.Map<Item>(itemDTO);
            //var res = await _itemService.AddItemAysnc(item);
            //return res == true ? (IActionResult)Ok(res) : BadRequest(res);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateItemAsync([FromBody] ItemDTO itemDTO)
        {
            var query = new UpdateItemCommand(itemDTO);
            var result = await _meadiator.Send(query);
            return result == true ? (IActionResult)Ok(result) : BadRequest(result);
            //var item = _mapper.Map<Item>(itemDTO);
            //var res = await _itemService.UpdateItemAysnc(item);
            //return res == true ? (IActionResult)Ok(res) : BadRequest(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemAsync(int id)
        {
            var query = new DeleteItemCommand(id);
            var result = await _meadiator.Send(query);
            return result == true ? (IActionResult)Ok(result) : BadRequest(result);
            //var res = await _itemService.DeleteItemAysnc(id);
            //return res == true ? (IActionResult)Ok(res) : BadRequest(res);
        }
        #endregion
    }
}
