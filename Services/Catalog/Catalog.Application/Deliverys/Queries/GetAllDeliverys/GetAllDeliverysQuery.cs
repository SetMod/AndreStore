using Catalog.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Deliverys.Queries.GetAllDeliverys
{
    public class GetAllDeliverysQuery : IRequest<IEnumerable<DeliveryDTO>>
    {
    }
}
