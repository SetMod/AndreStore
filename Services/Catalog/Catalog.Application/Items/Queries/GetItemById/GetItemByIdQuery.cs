using Catalog.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Items.Queries.GetItemById
{
    public class GetItemByIdQuery : IRequest<ItemDTO>
    {
        public GetItemByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
