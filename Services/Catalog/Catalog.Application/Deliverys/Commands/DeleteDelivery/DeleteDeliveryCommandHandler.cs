using AutoMapper;
using Catalog.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Catalog.Application.Deliverys.Commands.DeleteDelivery
{
    public class DeleteDeliveryCommandHandler : IRequestHandler<DeleteDeliveryCommand, bool>
    {
        private readonly IDeliveryService _deliveryService;
        private readonly IMapper _mapper;
        public DeleteDeliveryCommandHandler(IDeliveryService deliveryService, IMapper mapper)
        {
            _deliveryService = deliveryService;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteDeliveryCommand request, CancellationToken cancellationToken)
        {
            return await _deliveryService.DeleteDeliveryAysnc(request.Id); ;
        }
    }
}
