using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Deliverys.Commands.DeleteDelivery
{
    public class DeleteDeliveryCommand : IRequest<bool>
    {
        public int Id { get; }
        public DeleteDeliveryCommand(int id)
        {
            Id = id;
        }

    }
}
