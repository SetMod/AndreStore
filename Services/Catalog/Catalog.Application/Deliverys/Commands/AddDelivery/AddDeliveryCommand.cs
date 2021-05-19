using Catalog.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Deliverys.Commands.AddDelivery
{
    public class AddDeliveryCommand : IRequest<bool>
    {
        public DeliveryDTO DeliveryDTO { get; }

        public AddDeliveryCommand(DeliveryDTO deliveryDTO)
        {
            DeliveryDTO = deliveryDTO;
        }

    }
}
