using Catalog.Application.Interfaces.IMongo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.DAL.MongoDBSettings
{
    public class MongoDBSettings : IMongoDBSettings
    {
        public string ConnectionString { get; set; }
        public string CollectionName { get; set; }
        public string DatabaseName { get; set; }
    }
}
