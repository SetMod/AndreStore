using Cart.API.Entities;
using Cart.API.Interfaces.IServices;
using Cart.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cart.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CartItemsController : ControllerBase
    {
        private ICartItemsService _cartItemsService;
        public CartItemsController(ICartItemsService cartItemsService)
        {
            _cartItemsService = cartItemsService;
        }

        #region CartItemsAPIs
        // GET: /Cart/cartItems Get all Carts
        [HttpGet]
        public async Task<IActionResult> GetAllCartItemsAsync()//IEnumerable<CartItems>
        {
            return Ok(await _cartItemsService.GetAllCartItemsAsync());
        }

        // GET: /Cart/cartItems/pagination Get all Carts
        [HttpGet("pagination")]
        public async Task<IActionResult> GetAllCartItemsAsync([FromQuery] CartItemsParameters cartItemParams)
        {
            return Ok(await _cartItemsService.GetAllCartItemsPaginationAsync(cartItemParams));
        }

        // GET: /Cart/cartItems/{Id} Get Cart by id
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCartItemByIdAsync(int Id)
        {
            return Ok(await _cartItemsService.GetCartItemByIdAsync(Id));
        }

        // POST: /Cart/cartItems Add new Cart
        [HttpPost]
        public async Task<IActionResult> AddCartItemAsync([FromBody] CartItems cart)
        {
            return Ok(await _cartItemsService.AddCartItemAsync(cart));
        }

        // PUT: /Cart/cartItems Update existing Cart
        [HttpPut]
        public async Task<IActionResult> UpdateCartItemAsync([FromBody] CartItems cartItem)
        {
            return Ok(await _cartItemsService.UpdateCartItemAsync(cartItem));
        }

        // DELETE: /Cart/cartItems/{Id} Delete existing cartItem
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartItemAsync(int id)
        {
            return Ok(await _cartItemsService.DeleteCartItemAsync(id));
        }
        #endregion
    }
}
