using Aggreagator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aggreagator.Services.Interfaces
{
    public interface IOrderingService
    {
        Task<IEnumerable<OrdersModel>> GetOrders(int customerId);
        Task<OrdersModel> GetOrder(int customerId, int orderId);
        Task<bool> AddOrder(int customerId, OrdersModel order);
        Task<bool> UpdateOrder(int customerId, OrdersModel order);
        Task<bool> DeleteOrder(int customerId, int orderId);
    }
}
