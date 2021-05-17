using Catalog.Application.Interfaces;
using Catalog.Application.Interfaces.IMongo;
using Catalog.Domain.Entities;

namespace Catalog.Infrastructure.Repositories
{
    public class DeliveryRepository : GenericRepository<Delivery>, IDeliveryRepository
    {
        public DeliveryRepository(IMongoDBSettings settings) : base(settings)
        {
            settings.CollectionName = "Delivery";
        }
    }
}
