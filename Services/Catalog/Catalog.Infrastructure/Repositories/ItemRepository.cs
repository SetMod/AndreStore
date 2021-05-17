﻿using Catalog.Application.Interfaces;
using Catalog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Catalog.Application.Interfaces.IMongo;

namespace Catalog.Infrastructure.Repositories
{
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        public ItemRepository(IMongoDBSettings settings) : base(settings)
        {
            settings.CollectionName = "Item";
        }
    }
}