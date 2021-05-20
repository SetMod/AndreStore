using Cart.API.Entities;
using Cart.API.Interfaces.IServices;
using Cart.API.Models;
using MassTransit;
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
        private readonly ICartService _cartService;
        private readonly IPublishEndpoint _publishEndpoint;
        public CartController(ICartService cartService, IPublishEndpoint publishEndpoint)
        {
            _cartService = cartService;
            _publishEndpoint = publishEndpoint;
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

        [HttpPost("Checkout")]
        public async Task<IActionResult> Checkout([FromBody] CartCheckout cartCheckout)
        {

            // get existing basket with total price
            var cart = await _cartService.GetCartByCustomerIdAsync(cartCheckout.CustomerId);
            if (cart == null)
            {
                return BadRequest();
            }

            // send checkout event to rabbitmq
            cartCheckout.TotalPrice = cart.TotalPrice;
            await _publishEndpoint.Publish<CartCheckout>(cartCheckout);

            // remove the basket
            await _cartService.DeleteCartAsync(cart.Id);

            return Accepted();
        }
        #endregion
    }
}
