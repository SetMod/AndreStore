using AutoMapper;
using Catalog.Application.DTO;
using Catalog.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Catalog.Application.Items.Queries.GetAllItemsPagination
{
    public class GetAllItemsPagiantionQueryHandler : IRequestHandler<GetAllItemsPagiantionQuery, IEnumerable<ItemDTO>>
    {
        private readonly IItemService _itemService;
        private readonly IMapper _mapper;
        public GetAllItemsPagiantionQueryHandler(IItemService itemService, IMapper mapper)
        {
            _itemService = itemService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ItemDTO>> Handle(GetAllItemsPagiantionQuery request, CancellationToken cancellationToken)
        {
            var res = await _itemService.GetAllItemsPaginationAsync(request.ItemParams);
            return _mapper.Map<IEnumerable<ItemDTO>>(res);
        }
    }
}
