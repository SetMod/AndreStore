using Cart.API.Entities;
using Cart.API.Interfaces.IServices;
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
    public class CartController : ControllerBase
    {
        private ICartService _cartService;
        private ICartItemsService _cartItemsService;
        public CartController(ICartService cartService, ICartItemsService cartItemsService)
        {
            _cartService = cartService;
            _cartItemsService = cartItemsService;
        }

        // GET: /Cart Get all Carts
        [HttpGet("hello")]
        public IActionResult GetHello()
        {
            return Ok("Hello from Cart!");
        }

        #region CartAPIs
        // GET: /Cart Get all Carts
        [HttpGet]
        public async Task<IActionResult> GetAllCartsAsync()//Task<IEnumerable<Entities.Cart>>
        {
            return Ok(await _cartService.GetAllCartsAsync());
        }

        // GET: /Cart/{Id} Get Cart by id
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCartByIdAsync(int Id)//Task<Entities.Cart>
        {
            return Ok(await _cartService.GetCartByIdAsync(Id));
        }

        // POST: /Cart Add new Cart
        [HttpPost]
        public async Task<IActionResult> AddCartAsync([FromBody] Entities.Cart cart)
        {
            return Ok(await _cartService.AddCartAsync(cart));
        }

        // PUT: /Cart Update existing Cart
        [HttpPut]
        public async Task<IActionResult> UpdateCartAsync([FromBody] Entities.Cart cart)
        {
            return Ok(await _cartService.UpdateCartAsync(cart));
        }

        // DELETE: /Cart/{Id} Delete existing Cart
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartAsync(int id)
        {
            return Ok(await _cartService.DeleteCartAsync(id));
        }
        #endregion

        #region CartItemsAPIs
        // GET: /Cart/cartItems Get all Carts
        [HttpGet("cartItems")]
        public async Task<IActionResult> GetAllCartItemsAsync()//IEnumerable<CartItems>
        {
            return Ok(await _cartItemsService.GetAllCartItemsAsync());
        }

        // GET: /Cart/cartItems/{Id} Get Cart by id
        [HttpGet("cartItems/{Id}")]
        public async Task<IActionResult> GetCartItemByIdAsync(int Id)
        {
            return Ok(await _cartItemsService.GetCartItemByIdAsync(Id));
        }

        // POST: /Cart/cartItems Add new Cart
        [HttpPost("cartItems")]
        public async Task<IActionResult> AddCartItemAsync([FromBody] CartItems cart)
        {
            return Ok(await _cartItemsService.AddCartItemAsync(cart));
        }

        // PUT: /Cart/cartItems Update existing Cart
        [HttpPut("cartItems")]
        public async Task<IActionResult> UpdateCartItemAsync([FromBody] CartItems cartItem)
        {
            return Ok(await _cartItemsService.UpdateCartItemAsync(cartItem));
        }

        // DELETE: /Cart/cartItems/{Id} Delete existing cartItem
        [HttpDelete("cartItems/{id}")]
        public async Task<IActionResult> DeleteCartItemAsync(int id)
        {
            return Ok(await _cartItemsService.DeleteCartItemAsync(id));
        }
        #endregion
    }
}
