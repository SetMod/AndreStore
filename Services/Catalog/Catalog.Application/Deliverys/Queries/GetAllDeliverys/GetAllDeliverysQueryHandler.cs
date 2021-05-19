using AutoMapper;
using Catalog.Application.DTO;
using Catalog.Application.Interfaces;
using Catalog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Catalog.Application.Deliverys.Queries.GetAllDeliverys
{
    public class GetAllDeliverysQueryHandler : IRequestHandler<GetAllDeliverysQuery, IEnumerable<DeliveryDTO>>
    {
        private readonly IDeliveryService _deliveryService;
        private readonly IMapper _mapper;
        public GetAllDeliverysQueryHandler(IDeliveryService deliveryService, IMapper mapper)
        {
            _deliveryService = deliveryService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DeliveryDTO>> Handle(GetAllDeliverysQuery request, CancellationToken cancellationToken)
        {
            var res = await _deliveryService.GetAllDeliverysAysnc();
            return _mapper.Map<IEnumerable<DeliveryDTO>>(res);
        }
    }
}
