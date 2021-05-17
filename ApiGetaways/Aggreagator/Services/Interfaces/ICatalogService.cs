﻿using Aggreagator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aggreagator.Services.Interfaces
{
    public interface ICatalogService
    {
        Task<IEnumerable<ItemsModel>> GetCatalog();
    }
}