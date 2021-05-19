using Catalog.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Deliverys.Queries.GetDeliveryById
{
    public class GetDeliveryByIdQuery : IRequest<DeliveryDTO>
    {
        public int Id { get;}
        public GetDeliveryByIdQuery(int Id)
        {
            this.Id = Id;
        }
    }
}
