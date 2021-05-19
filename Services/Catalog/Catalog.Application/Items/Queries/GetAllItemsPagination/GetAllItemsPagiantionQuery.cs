using Catalog.Application.DTO;
using Catalog.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Items.Queries.GetAllItemsPagination
{
    public class GetAllItemsPagiantionQuery : IRequest<IEnumerable<ItemDTO>>
    {
        public ItemParameters ItemParams { get; set; }
        public GetAllItemsPagiantionQuery(ItemParameters itemParams)
        {
            ItemParams = itemParams;
        }
    }
}
