using Catalog.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Deliverys.Commands.UpdateDelivery
{
    public class UpdateDeliveryCommand : IRequest<bool>
    {
        public DeliveryDTO DeliveryDTO { get; }
        public UpdateDeliveryCommand(DeliveryDTO deliveryDTO)
        {
            DeliveryDTO = deliveryDTO;
        }

    }
}
