using Aggregator.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aggregator.API.Services.Interfaces
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
