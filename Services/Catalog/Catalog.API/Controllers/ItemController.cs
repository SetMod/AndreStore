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
        private IItemService _itemService { get; }
        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        #region ItemsAPI
        [HttpGet]
        public async Task<IActionResult> GetAllItems() //IEnumerable<Item>
        {
            return Ok(await _itemService.GetAllItemsAysnc());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemByIdAsync(int id)
        {
            return Ok(await _itemService.GetItemByIdAysnc(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddItemAsync([FromBody] Item item)
        {
            var res = await _itemService.AddItemAysnc(item);
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
        public async Task<IActionResult> UpdateItemAsync([FromBody] Item item)
        {
            var res = await _itemService.UpdateItemAysnc(item);
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
        public async Task<IActionResult> DeleteItemAsync(int id)
        {
            var res = await _itemService.DeleteItemAysnc(id);
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
