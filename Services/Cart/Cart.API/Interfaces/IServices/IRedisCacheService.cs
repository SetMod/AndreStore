using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cart.API.Interfaces.IServices
{
    public interface IRedisCacheService
    {
        //public Task<string> GetCacheValueAsync(string key);
        //public Task<bool> SetCacheValueAsync(string key, string value);
        public Task<T> GetRecordAsync<T>(string recordId);
        public Task SetRecordAsync<T>(string recordId, T data, TimeSpan? timeSpan = null);
    }
}
