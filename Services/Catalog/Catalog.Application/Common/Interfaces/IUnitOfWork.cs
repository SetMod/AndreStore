using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Interfaces
{
    public interface IUnitOfWork
    {
        public IItemRepository itemRepository { get; }
        public IDeliveryRepository deliveryRepository { get; }
    }
}
