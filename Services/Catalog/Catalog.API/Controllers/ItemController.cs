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
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        private readonly IMapper _mapper;
        public ItemController(IItemService itemService, IMapper mapper)
        {
            _itemService = itemService;
            _mapper = mapper;
        }

        #region ItemsAPI
        [HttpGet]
        public async Task<IActionResult> GetAllItems() //IEnumerable<Item>
        {
            var res = await _itemService.GetAllItemsAysnc();
            var resDTO = _mapper.Map<IEnumerable<ItemDTO>>(res);
            return Ok(resDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemByIdAsync(int id)
        {
            var res = await _itemService.GetItemByIdAysnc(id);
            if (res == null)
            {
                return NotFound(res);
            }
            var resDTO = _mapper.Map<IEnumerable<ItemDTO>>(res);
            return Ok(resDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddItemAsync([FromBody] ItemDTO itemDTO)
        {
            var item = _mapper.Map<Item>(itemDTO);
            var res = await _itemService.AddItemAysnc(item);
            if (!res)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateItemAsync([FromBody] ItemDTO itemDTO)
        {
            var item = _mapper.Map<Item>(itemDTO);
            var res = await _itemService.UpdateItemAysnc(item);
            if (!res)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemAsync(int id)
        {
            var res = await _itemService.DeleteItemAysnc(id);
            if (!res)
            {
                return NotFound(res);
            }
            return Ok(res);
        }
        #endregion
    }
}
