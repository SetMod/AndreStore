using Catalog.Domain.Entities;
using Catalog.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Interfaces
{
    public interface IItemRepository : IGenericRepository<Item>
    {
    }
}
