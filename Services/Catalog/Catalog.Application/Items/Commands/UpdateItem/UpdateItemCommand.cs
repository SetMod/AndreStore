using Catalog.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Items.Commands.UpdateItem
{
    public class UpdateItemCommand : IRequest<bool>
    {
        public UpdateItemCommand(ItemDTO itemDTO)
        {
            ItemDTO = itemDTO;
        }

        public ItemDTO ItemDTO { get; }
    }
}
