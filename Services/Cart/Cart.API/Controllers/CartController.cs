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
    public class CartController : ControllerBase
    {
        private ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
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

        // GET: /Cart/customerId={Id} Get Cart by id
        [HttpGet("customerId={customerId}")]
        public async Task<IActionResult> GetCartByCustomerIdAsync(int customerId)
        {
            return Ok(await _cartService.GetCartByCustomerIdAsync(customerId));
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
    }
}
