using Ordering.BLL.Interfaces.IServices;
using Ordering.DAL.Entities;
using Ordering.DAL.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.BLL.Services
{
    public class OrderingService : IOrderingService
    {
        private readonly IOrderingRepository _orderRpo;

        public OrderingService(IOrderingRepository orderRpo)
        {
            _orderRpo = orderRpo;
        }

        public async Task<IEnumerable<Orders>> GetAllOrders()
        {
            return await _orderRpo.GetAllAsync();
        }

        public async Task<Orders> GetOrder(int id)
        {
            return await _orderRpo.GetByIdAsync(id);
        }

        public async Task<Orders> AddOrder(Orders order)
        {
            return await _orderRpo.AddAsync(order);
        }

        public async Task<Orders> UpdateOrder(Orders order)
        {
            return await _orderRpo.UpdateAsync(order);
        }

        public async Task<Orders> DeleteOrder(int id)
        {
            return await _orderRpo.DeleteAsync(id);
        }
    }
}
