using Ordering.BLL.Interfaces.IServices;
using Ordering.BLL.Interfaces.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.BLL.UnitOfWork
{
    public class OrderingUnitOfWork : IOrderingUnitOfWork
    {
        private readonly IOrderingService _orderService;
        public OrderingUnitOfWork(IOrderingService orderService)
        {
            _orderService = orderService;
        }
        public IOrderingService orderService { get { return _orderService; } }
    }
}
