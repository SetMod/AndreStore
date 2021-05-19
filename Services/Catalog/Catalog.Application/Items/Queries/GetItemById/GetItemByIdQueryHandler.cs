using AutoMapper;
using Catalog.Application.DTO;
using Catalog.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Catalog.Application.Items.Queries.GetItemById
{
    public class GetItemByIdQueryHandler : IRequestHandler<GetItemByIdQuery, ItemDTO>
    {
        private readonly IItemService _itemService;
        private readonly IMapper _mapper;
        public GetItemByIdQueryHandler(IItemService itemService, IMapper mapper)
        {
            _itemService = itemService;
            _mapper = mapper;
        }
        public async Task<ItemDTO> Handle(GetItemByIdQuery request, CancellationToken cancellationToken)
        {
            var res = await _itemService.GetItemByIdAysnc(request.Id);
            return res != null ? _mapper.Map<ItemDTO>(res) : null;
        }
    }
}
