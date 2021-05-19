using AutoMapper;
using Catalog.Application.DTO;
using Catalog.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Catalog.Application.Deliverys.Queries.GetDeliveryById
{
    public class GetDeliveryByIdQueryHandler : IRequestHandler<GetDeliveryByIdQuery, DeliveryDTO>
    {
        private readonly IDeliveryService _deliveryService;
        private readonly IMapper _mapper;
        public GetDeliveryByIdQueryHandler(IDeliveryService deliveryService, IMapper mapper)
        {
            _deliveryService = deliveryService;
            _mapper = mapper;
        }
        public async Task<DeliveryDTO> Handle(GetDeliveryByIdQuery request, CancellationToken cancellationToken)
        {
            var res = await _deliveryService.GetDeliveryByIdAysnc(request.Id);
            return res == null? null : _mapper.Map<DeliveryDTO>(res);
        }
    }
}
