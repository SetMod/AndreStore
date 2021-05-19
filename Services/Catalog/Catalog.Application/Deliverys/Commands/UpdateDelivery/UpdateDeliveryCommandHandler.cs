using AutoMapper;
using Catalog.Application.Interfaces;
using Catalog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Catalog.Application.Deliverys.Commands.UpdateDelivery
{
    public class UpdateDeliveryCommandHandler : IRequestHandler<UpdateDeliveryCommand, bool>
    {
        private readonly IDeliveryService _deliveryService;
        private readonly IMapper _mapper;
        public UpdateDeliveryCommandHandler(IDeliveryService deliveryService, IMapper mapper)
        {
            _deliveryService = deliveryService;
            _mapper = mapper;
        }
        public async Task<bool> Handle(UpdateDeliveryCommand request, CancellationToken cancellationToken)
        {
            var delivery = _mapper.Map<Delivery>(request.DeliveryDTO);
            return await _deliveryService.UpdateDeliveryAysnc(delivery);
        }
    }
}
