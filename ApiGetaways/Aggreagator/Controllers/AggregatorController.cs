using Aggregator.API.Models;
using Aggregator.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Aggregator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AggregatorController : ControllerBase
    {

        private readonly ICatalogService _catalogService;
        private readonly ICartService _cartService;
        private readonly IOrderingService _orderService;

        public AggregatorController(ICatalogService catalogService, ICartService cartService, IOrderingService orderService)
        {
            _catalogService = catalogService ?? throw new ArgumentNullException(nameof(catalogService));
            _cartService = cartService ?? throw new ArgumentNullException(nameof(cartService));
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        }

        [HttpGet("GetCart/{customerId}")]
        [ProducesResponseType(typeof(ItemsModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCart(int customerId)
        {
            var cart = await _cartService.GetCart(customerId);
            var cartItems = await _cartService.GetAllCartItems(cart.Id);
            //var orders = await _orderService.GetOrders(customerId);
            return Ok(cartItems);
        }

        [HttpGet]
        public string GetHello()
        {
            return "Hello from Aggregator";
        }
    }
}
