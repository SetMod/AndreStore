using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aggreagator.Models
{
    public class ItemsModel
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
