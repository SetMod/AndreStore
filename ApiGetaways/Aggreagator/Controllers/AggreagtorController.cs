using Aggreagator.Models;
using Aggreagator.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Aggreagator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AggreagtorController : ControllerBase
    {

        private readonly ICatalogService _catalogService;
        private readonly ICartService _cartService;
        private readonly IOrderingService _orderService;

        public AggreagtorController(ICatalogService catalogService, ICartService cartService, IOrderingService orderService)
        {
            _catalogService = catalogService ?? throw new ArgumentNullException(nameof(catalogService));
            _cartService = cartService ?? throw new ArgumentNullException(nameof(cartService));
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        }

        [HttpGet("GetCart")]
        [ProducesResponseType(typeof(ResultModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResultModel>> GetCart(int customerId)
        {
            var catalog = await _catalogService.GetCatalog();
            var cart = await _cartService.GetCart(customerId);
            var orders = await _orderService.GetOrders(customerId);

            //foreach (var item in basket.Items)
            //{
            //    var product = await _catalogService.GetCatalog(item.ProductId);

            //    // set additional product fields
            //    item.ProductName = product.Name;
            //    item.Category = product.Category;
            //    item.Summary = product.Summary;
            //    item.Description = product.Description;
            //    item.ImageFile = product.ImageFile;
            //}

            //var orders = await _orderService.GetOrdersByUserName(userName);

            var resultModel = new ResultModel{};

            return Ok(resultModel);
        }

        [HttpGet]
        public string GetHello()
        {
            return "Hello from Aggregator";
        }
    }
}
