using Cart.API.Interfaces.IServices;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cart.API.Services
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly IConnectionMultiplexer _conMultiplexer;
        public RedisCacheService(IConnectionMultiplexer conMultiplexer)
        {
            _conMultiplexer = conMultiplexer;
        }

        public async Task<T> GetRecordAsync<T>(string recordId)
        {
            var db = _conMultiplexer.GetDatabase();
            var jsonData =  await db.StringGetAsync(recordId);

            if (string.IsNullOrEmpty(jsonData))
            {
                return default(T);
            }
            return JsonSerializer.Deserialize<T>(jsonData);
        }

        public async Task SetRecordAsync<T>(string recordId,T data,TimeSpan? timeSpan = null)
        {
            var db = _conMultiplexer.GetDatabase();
            var jsonData = JsonSerializer.Serialize(data);
            await db.StringSetAsync(recordId, jsonData, timeSpan);
        }

        //public async Task<string> GetCacheValueAsync(string key)
        //{
        //    var db = _conMultiplexer.GetDatabase();
        //    return await db.StringGetAsync(key);
        //}

        //public async Task<bool> SetCacheValueAsync(string key, string value)
        //{
        //    var db = _conMultiplexer.GetDatabase();
        //    return await db.StringSetAsync(key, value);
        //}

    }
}
