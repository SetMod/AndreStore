using AutoMapper;
using Cart.API.DTO;
using Cart.API.Entities;
using Cart.API.GrpcServices;
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
        private readonly DiscountGrpcService _discountGrpcService;
        private readonly ICartItemsService _cartItemsService;
        private readonly IRedisCacheService _cacheService;
        private readonly IMapper _mapper;
        public CartItemsController(
            DiscountGrpcService discountGrpcService,
            ICartItemsService cartItemsService,
            IRedisCacheService cacheService,
            IMapper mapper)
        {
            _discountGrpcService = discountGrpcService;
            _cartItemsService = cartItemsService;
            _cacheService = cacheService;
            _mapper = mapper;
        }


        #region CartItemsAPIs
        // GET: /CartItems Get all CartItems
        [HttpGet]
        public async Task<IActionResult> GetAllCartItemsAsync(string? recordKey = null)//IEnumerable<CartItems>
        {
            if (string.IsNullOrEmpty(recordKey))
            {
                var cartItems = await _cartItemsService.GetAllCartItemsAsync();
                var cartItemsDTO = _mapper.Map<IEnumerable<CartItemsDTO>>(cartItems);
                return Ok(cartItemsDTO);
            }

            var casheItem = await _cacheService.GetRecordAsync<IEnumerable<CartItemsDTO>>(recordKey);

            if (casheItem == null)
            {
                var cartItems = await _cartItemsService.GetAllCartItemsAsync();
                var cartItemsDTO = _mapper.Map<IEnumerable<CartItemsDTO>>(cartItems);
                await _cacheService.SetRecordAsync<IEnumerable<CartItemsDTO>>(recordKey, cartItemsDTO, TimeSpan.FromSeconds(3600));
            }

            return Ok(casheItem);
        }

        // GET: /CartItems/pagination Get all CartItems
        [HttpGet("pagination")]
        public async Task<IActionResult> GetAllCartItemsAsync([FromQuery] CartItemsParameters cartItemParams, string? recordKey = null)
        {
            if (string.IsNullOrEmpty(recordKey))
            {
                var cartItems = await _cartItemsService.GetAllCartItemsPaginationAsync(cartItemParams);
                var cartItemsDTO = _mapper.Map<IEnumerable<CartItemsDTO>>(cartItems);
                return Ok(cartItemsDTO);
            }

            var casheItem = await _cacheService.GetRecordAsync<IEnumerable<CartItemsDTO>>(recordKey);

            if (casheItem == null)
            {
                var cartItems = await _cartItemsService.GetAllCartItemsPaginationAsync(cartItemParams);
                var cartItemsDTO = _mapper.Map<IEnumerable<CartItemsDTO>>(cartItems);
                await _cacheService.SetRecordAsync<IEnumerable<CartItemsDTO>>(recordKey, cartItemsDTO, TimeSpan.FromSeconds(3600));
            }

            return Ok(casheItem);
        }

        // GET: /CartItems/ Get all CartItems
        [HttpGet("cartId={cartId}")]
        public async Task<IActionResult> GetAllCartItemsForCartAsync(int cartId, [FromQuery] CartItemsParameters cartItemParams, string? recordKey = null)
        {
            if (string.IsNullOrEmpty(recordKey))
            {
                var cartItems = await _cartItemsService.GetAllCartItemsForCartAsync(cartId, cartItemParams);
                var cartItemsDTO = _mapper.Map<IEnumerable<CartItemsDTO>>(cartItems);

                //gRPC
                //foreach (var item in cartItemsDTO)
                //{
                //    var coupon = await _discountGrpcService.GetDiscount(item.ProductName);
                //    item.Price -= coupon.Amount;
                //}

                return Ok(cartItemsDTO);
            }

            var casheItem = await _cacheService.GetRecordAsync<IEnumerable<CartItemsDTO>>(recordKey);

            if (casheItem == null)
            {
                var cartItems = await _cartItemsService.GetAllCartItemsPaginationAsync(cartItemParams);
                var cartItemsDTO = _mapper.Map<IEnumerable<CartItemsDTO>>(cartItems);
                await _cacheService.SetRecordAsync<IEnumerable<CartItemsDTO>>(recordKey, cartItemsDTO, TimeSpan.FromSeconds(3600));
            }

            return Ok(casheItem);
        }

        // GET: /CartItems/{Id} Get CartItem by id
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCartItemByIdAsync(int Id)
        {
            return Ok(await _cartItemsService.GetCartItemByIdAsync(Id));
        }

        // POST: /CartItems Add new CartItem
        [HttpPost]
        public async Task<IActionResult> AddCartItemAsync([FromBody] CartItems cart)
        {
            return Ok(await _cartItemsService.AddCartItemAsync(cart));
        }

        // PUT: /CartItems Update existing CartItem
        [HttpPut]
        public async Task<IActionResult> UpdateCartItemAsync([FromBody] CartItems cartItem)
        {
            return Ok(await _cartItemsService.UpdateCartItemAsync(cartItem));
        }

        // DELETE: /CartItems/{Id} Delete existing CartItem
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartItemAsync(int id)
        {
            return Ok(await _cartItemsService.DeleteCartItemAsync(id));
        }
        #endregion
    }
}
