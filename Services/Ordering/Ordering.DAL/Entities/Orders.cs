using Ordering.DAL.Interfaces.IEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.DAL.Entities
{
    public class Orders : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public int Amount { get; set; }
    }
}
