using Cart.API.Interfaces.IConnectionFacory;
using Cart.API.Interfaces.IEntities;
using Cart.API.Interfaces.IRpositories;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Cart.API.Repositories
{
    public class GenericRpository<T> : IGenericRepository<T> where T : IEntity
    {
        protected ICartConnectionFactory _connectionFactory;
        private readonly string _tableName;
        private readonly string _IdName;

        public GenericRpository(ICartConnectionFactory connectionFactory, string tableName, string idName = "Id")
        {
            _connectionFactory = connectionFactory;
            _tableName = tableName;
            _IdName = idName;
        }

        private IEnumerable<string> GetColumns()
        {
            return typeof(T)
                    .GetProperties()
                    .Where(e => e.Name != "Id" && !e.PropertyType.GetTypeInfo().IsGenericType)
                    .Select(e => e.Name);
        }

        private IEnumerable<string> GetProperties(T entity)
        {
            return typeof(T)
                    .GetProperties()
                    .Where(e => e.Name != "Id" && e.GetValue(entity) != null && !e.PropertyType.GetTypeInfo().IsGenericType)
                    .Select(e => e.GetValue(entity).ToString());//.Select(e => '\'' + e.GetValue(entity).ToString() + '\'');
        }

        private IEnumerable<string> GetPropertiesUpdate(T entity)
        {
            return typeof(T)
                    .GetProperties()
                    .Where(e => e.Name != "Id" && e.GetValue(entity) != null && !e.PropertyType.GetTypeInfo().IsGenericType)
                    .Select(e => e.Name + " = " + '\'' + e.GetValue(entity).ToString() + '\'');
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var query = "SP_GetAllRecordsFromTable";

            using (var db = _connectionFactory.GetSqlConnection)
            {
                return await db.QueryAsync<T>(query,
                    new { P_tableName = _tableName },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<T> GetByIdAsync(int Id)
        {
            var query = "SP_GetRecordByIdFromTable";

            using (var db = _connectionFactory.GetSqlConnection)
            {
                var items = await db.QueryAsync<T>(query,
                    new { P_tableName = _tableName, P_IdName = _IdName, P_Id = Id },
                    commandType: CommandType.StoredProcedure);
                return items.FirstOrDefault(item => item.Id == Id);
            }
        }

        public async Task<bool> AddAsync(T entity)
        {
            var columns = GetColumns();
            var stringOfColumns = string.Join(", ", columns);
            var stringOfProperties = string.Join(", ", GetProperties(entity)); ;
            var query = "SP_InsertRecordToTable";
/*            try
            {*/
                using (var db = _connectionFactory.GetSqlConnection)
                {
                    var InsertionStatement = await db.QueryFirstAsync<int>(
                    sql: query,
                    param: new { P_tableName = _tableName, P_columnsString = stringOfColumns, P_propertiesString = stringOfProperties },
                    commandType: CommandType.StoredProcedure);
                    return true;
                }
/*            }
            catch (Exception e)
            {
                Console.Write(e);
                return false;
            }*/
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            var stringOfColumns = string.Join(", ", GetPropertiesUpdate(entity));
            //var query = "SP_UpdateRecordInTable";
            var query = "SP_UpdateRecordInTableInOneString";
            try
            {
                using (var db = _connectionFactory.GetSqlConnection)
                {
                    var UpdateStatement = await db.QueryFirstAsync<string>(
                    sql: query,
                    param: new { P_tableName = _tableName, P_columnsString = stringOfColumns, P_IdName = _IdName, P_Id = entity.Id },
                    commandType: CommandType.StoredProcedure);
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.Write(e);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            var query = "SP_DeleteRecordFromTable";
            try
            {
                using (var db = _connectionFactory.GetSqlConnection)
                {
                    var result = await db.ExecuteAsync(
                    sql: query,
                    param: new { P_tableName = _tableName, P_IdName = _IdName, P_Id = Id },
                    commandType: CommandType.StoredProcedure);
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.Write(e);
                return false;
            }
        }
    }
}