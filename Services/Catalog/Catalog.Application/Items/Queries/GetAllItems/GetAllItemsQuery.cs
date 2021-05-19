using Catalog.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Items.Queries.GetAllItems
{
    public class GetAllItemsQuery : IRequest<IEnumerable<ItemDTO>>
    {
    }
}
