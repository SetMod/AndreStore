using Cart.API.Entities;
using Cart.API.Interfaces.IConnectionFacory;
using Cart.API.Interfaces.IRpositories;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Cart.API.Repositories
{
    public class CartRepository : GenericRpository<Entities.Cart>, ICartRepository
    {
        public CartRepository(ICartConnectionFactory connectionFactory) : base(connectionFactory, "Cart")
        {
        }

        public async Task<Entities.Cart> GetCartByCustomerIdAsync(int customerId)
        {
            var query = "SP_GetRecordByIdFromTable";

            using (var db = _connectionFactory.GetSqlConnection)
            {
                this._IdName = "CustomerId";
                var items = await db.QueryAsync<Entities.Cart>(query,
                    new { P_tableName = this._tableName, P_IdName = this._IdName, P_Id = customerId },
                    commandType: CommandType.StoredProcedure);
                return items.FirstOrDefault(item => item.CustomerId == customerId);
            }
        }
    }
}
