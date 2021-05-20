using MassTransit;
using Ordering.BLL.Interfaces.IServices;
using Oredering.API.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oredering.API.EventBusConsumer
{
    public class CartCheckoutConsumer : IConsumer<CartCheckoutEvent>
    {
        private readonly IOrderingService _orderService;
        public CartCheckoutConsumer(IOrderingService orderService)
        {
            _orderService = orderService;
        }
        public async Task Consume(ConsumeContext<CartCheckoutEvent> context)
        {
            await _orderService.AddOrder(context.Message);
        }
    }
}
