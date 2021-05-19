using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Items.Commands.DeleteItem
{
    public class DeleteItemCommand : IRequest<bool>
    {
        public DeleteItemCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
