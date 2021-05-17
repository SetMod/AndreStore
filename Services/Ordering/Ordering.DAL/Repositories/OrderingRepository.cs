using Ordering.DAL.Entities;
using Ordering.DAL.Interfaces.IRepositories;
using Oredering.DAL.OrderigDbContext;

namespace Ordering.DAL.Repositories
{
    public class OrderingRepository : GenericRepository<Orders>, IOrderingRepository
    {
        public OrderingRepository(OrderingDbContext context) : base(context)
        {
        }
    }
}
