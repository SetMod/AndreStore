using Cart.API.Interfaces.IConnectionFacory;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Cart.API.ConnectionFactory
{
    public class CartConnectionFactory : ICartConnectionFactory
    {
        private readonly IConfiguration configuation;
        private static string _connectionString;

        public CartConnectionFactory(IConfiguration Configuation)
        {
            configuation = Configuation;
        }
        public void SetConnection(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection GetSqlConnection
        {
            get
            {
                SqlConnection connection;
                if (!string.IsNullOrEmpty(_connectionString))
                    connection = new SqlConnection(_connectionString);
                else
                    connection = new SqlConnection(configuation.GetValue<string>("connectionString:DefaultConnection"));
                connection.Open();
                return connection;
            }
        }
    }
}
