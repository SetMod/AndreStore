using Ordering.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.BLL.Interfaces.IServices
{
    public interface IOrderingService
    {
        Task<IEnumerable<Orders>> GetAllOrders();
        Task<Orders> GetOrder(int id);
        Task<Orders> AddOrder(Orders order);
        Task<Orders> UpdateOrder(Orders order);
        Task<Orders> DeleteOrder(int id);
    }
}
