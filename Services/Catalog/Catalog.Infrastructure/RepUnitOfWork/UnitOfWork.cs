using Catalog.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Infrastructure.RepUnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IItemRepository _itemRepository;
        private readonly IDeliveryRepository _deliveryRepository;

        public UnitOfWork(IItemRepository itemRepository, IDeliveryRepository deliveryRepository)
        {
            _itemRepository = itemRepository;
            _deliveryRepository = deliveryRepository;
        }
        public IItemRepository itemRepository { get { return _itemRepository; } }
        public IDeliveryRepository deliveryRepository { get { return _deliveryRepository; } }
    }
}
