using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Interfaces.IMongo
{
    public interface IMongoDBSettings
    {
        string ConnectionString { get; set; }
        string CollectionName { get; set; }
        string DatabaseName { get; set; }
    }
}
