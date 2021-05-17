using Cart.API.Entities;
using Cart.API.Interfaces.IUnitOfWork;
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
        private IUnitOfWork _unitOfWork;
        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: /Cart Get all Carts
        [HttpGet("hello")]
        public string GetHello()
        {
            return "Hello from Cart!";
        }

        #region CartAPIs
        // GET: /Cart Get all Carts
        [HttpGet]
        public async Task<IEnumerable<Entities.Cart>> GetAllCartsAsync()
        {
            return await _unitOfWork.cartService.GetAllCartsAsync();
        }

        // GET: /Cart/{Id} Get Cart by id
        [HttpGet("{Id}")]
        public async Task<Entities.Cart> GetCartByIdAsync(int Id)
        {
            return await _unitOfWork.cartService.GetCartByIdAsync(Id);
        }

        // POST: /Cart Add new Cart
        [HttpPost]
        public async Task<bool> AddCartAsync([FromBody] Entities.Cart cart)
        {
            return await _unitOfWork.cartService.AddCartAsync(cart);
        }

        // PUT: /Cart Update existing Cart
        [HttpPut]
        public async Task<bool> UpdateCartAsync([FromBody] Entities.Cart cart)
        {
            return await _unitOfWork.cartService.UpdateCartAsync(cart);
        }

        // DELETE: /Cart/{Id} Delete existing Cart
        [HttpDelete("{id}")]
        public async Task<bool> DeleteCartAsync(int id)
        {
            return await _unitOfWork.cartService.DeleteCartAsync(id);
        }
        #endregion

        #region CartItemsAPIs
        // GET: /Cart/cartItems Get all Carts
        [HttpGet("cartItems")]
        public async Task<IEnumerable<CartItems>> GetAllCartItemsAsync()
        {
            return await _unitOfWork.cartItemsService.GetAllCartItemsAsync();
        }

        // GET: /Cart/cartItems/{Id} Get Cart by id
        [HttpGet("cartItems/{Id}")]
        public async Task<CartItems> GetCartItemByIdAsync(int Id)
        {
            return await _unitOfWork.cartItemsService.GetCartItemByIdAsync(Id);
        }

        // POST: /Cart/cartItems Add new Cart
        [HttpPost("cartItems")]
        public async Task<bool> AddCartItemAsync([FromBody] CartItems cart)
        {
            return await _unitOfWork.cartItemsService.AddCartItemAsync(cart);
        }

        // PUT: /Cart/cartItems Update existing Cart
        [HttpPut("cartItems")]
        public async Task<bool> UpdateCartItemAsync([FromBody] CartItems cartItem)
        {
            return await _unitOfWork.cartItemsService.UpdateCartItemAsync(cartItem);
        }

        // DELETE: /Cart/cartItems/{Id} Delete existing cartItem
        [HttpDelete("cartItems/{id}")]
        public async Task<bool> DeleteCartItemAsync(int id)
        {
            return await _unitOfWork.cartItemsService.DeleteCartItemAsync(id);
        }
        #endregion
    }
}
