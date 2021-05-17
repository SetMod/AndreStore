using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Cart.API.Interfaces.IConnectionFacory
{
    public interface ICartConnectionFactory
    {
        public IDbConnection GetSqlConnection { get; }
        public void SetConnection(string connectionString);
    }
}
