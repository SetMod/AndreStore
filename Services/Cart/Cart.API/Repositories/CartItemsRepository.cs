using Cart.API.Entities;
using Cart.API.Helpers;
using Cart.API.Interfaces.IConnectionFacory;
using Cart.API.Interfaces.IRpositories;
using Cart.API.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Cart.API.Repositories
{
    public class CartItemsRepository : GenericRpository<CartItems>, ICartItemsRepository
    {
        public CartItemsRepository(ICartConnectionFactory connectionFactory) : base(connectionFactory, "CartItems")
        {
        }

        public async Task<PagedList<CartItems>> GetAllItemsPagination(CartItemsParameters cartItemParams)
        {
            // Filtering example
            //var owners = FindByCondition(o => o.DateOfBirth.Year >= ownerParameters.MinYearOfBirth &&
            //                o.DateOfBirth.Year <= ownerParameters.MaxYearOfBirth)
            //            .OrderBy(on => on.Name);

            var res = await GetAllAsync();
            return PagedList<CartItems>.ToPagedList(res,
                cartItemParams.PageNumber,
                cartItemParams.PageSize);
        }
        public async Task<PagedList<Item>> GetAllCartItemsForCartAsync(int cartId, CartItemsParameters cartItemParams)
        {

            var query = "SP_GetRecordByIdFromTable";

            using (var db = _connectionFactory.GetSqlConnection)
            {
                this._IdName = "CartId";
                var cartItems = await db.QueryAsync<CartItems>(query,
                    new { P_tableName = this._tableName, P_IdName = this._IdName, P_Id = cartId },
                    commandType: CommandType.StoredProcedure);

                var items = new List<Item>();
                foreach (var item in cartItems)
                {
                    var itemCart = await db.QueryFirstOrDefaultAsync<Item>(query,
                        new { P_tableName = "Items", P_IdName = "Id", P_Id = item.ItemId },
                        commandType: CommandType.StoredProcedure);
                    itemCart.Amount = item.Amount;
                    items.Add(itemCart);
                }
                return PagedList<Item>.ToPagedList(items,
                cartItemParams.PageNumber,
                cartItemParams.PageSize);
            }

        }
    }
}
