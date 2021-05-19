using AutoMapper;
using Catalog.Application.Interfaces;
using Catalog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Catalog.Application.Items.Commands.AddItem
{
    public class AddItemCommandHandelr : IRequestHandler<AddItemCommand, bool>
    {
        private readonly IItemService _itemService;
        private readonly IMapper _mapper;
        public AddItemCommandHandelr(IItemService itemService, IMapper mapper)
        {
            _itemService = itemService;
            _mapper = mapper;
        }

        public async Task<bool> Handle(AddItemCommand request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<Item>(request.ItemDTO);
            return await _itemService.AddItemAysnc(item);
        }
    }
}
