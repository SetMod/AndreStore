using AutoMapper;
using Catalog.Application.DTO;
using Catalog.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Catalog.Application.Items.Queries.GetAllItems
{
    public class GetAllItemsQueryHandler : IRequestHandler<GetAllItemsQuery, IEnumerable<ItemDTO>>
    {
        private readonly IItemService _itemService;
        private readonly IMapper _mapper;
        public GetAllItemsQueryHandler(IItemService itemService, IMapper mapper)
        {
            _itemService = itemService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ItemDTO>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
        {
            var res = await _itemService.GetAllItemsAysnc();
            return _mapper.Map<IEnumerable<ItemDTO>>(res);
        }
    }
}
