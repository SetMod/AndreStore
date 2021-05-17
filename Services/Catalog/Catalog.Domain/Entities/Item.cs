using Catalog.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Domain.Entities
{
    public class Item : IEntity
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int DeliveryId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Category { get; set; }
        public int Amount { get; set; }
    }
}
