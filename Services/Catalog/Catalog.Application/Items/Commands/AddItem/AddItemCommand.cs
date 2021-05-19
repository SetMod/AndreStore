using Catalog.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Items.Commands.AddItem
{
    public class AddItemCommand : IRequest<bool>
    {
        public AddItemCommand(ItemDTO itemDTO)
        {
            ItemDTO = itemDTO;
        }

        public ItemDTO ItemDTO { get; }
    }
}
