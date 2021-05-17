using Catalog.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Domain.Entities
{
    public class Delivery : IEntity
    {
        public int Id { get; set; }
        public string DeliveryType { get; set; }
        public decimal Price { get; set; }
        public int DeliveryTime { get; set; }
    }
}
