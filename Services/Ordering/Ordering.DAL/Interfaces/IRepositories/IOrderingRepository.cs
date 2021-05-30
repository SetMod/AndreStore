using Ordering.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.DAL.Interfaces.IRepositories
{
    public interface IOrderingRepository : IGenericRepository<Orders>
    {
        Task<IEnumerable<Orders>> GetAllOrdersByCustomerIdAsync(int customerId);
    }
}
