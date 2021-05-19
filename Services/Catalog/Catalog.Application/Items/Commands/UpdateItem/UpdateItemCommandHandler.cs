using AutoMapper;
using Catalog.Application.Interfaces;
using Catalog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Catalog.Application.Items.Commands.UpdateItem
{
    public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand, bool>
    {
        private readonly IItemService _itemService;
        private readonly IMapper _mapper;
        public UpdateItemCommandHandler(IItemService itemService, IMapper mapper)
        {
            _itemService = itemService;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<Item>(request.ItemDTO);
            return await _itemService.UpdateItemAysnc(item);
        }
    }
}
