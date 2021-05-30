using Microsoft.EntityFrameworkCore;
using Ordering.DAL.Entities;
using Ordering.DAL.Interfaces.IRepositories;
using Oredering.DAL.OrderigDbContext;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ordering.DAL.Repositories
{
    public class OrderingRepository : GenericRepository<Orders>, IOrderingRepository
    {
        private readonly OrderingDbContext _context;
        public OrderingRepository(OrderingDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Orders>> GetAllOrdersByCustomerIdAsync(int customerId)
        {
            var orders = await _context.Orders.ToListAsync();
            var res = new List<Orders>();
            foreach (var order in orders)
            {
                if (order.CustomerId == customerId)
                {
                    res.Add(order);
                }
            }
            return res;
        }
    }
}
