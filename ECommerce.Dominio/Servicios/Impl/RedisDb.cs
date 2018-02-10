using ECommerce.Dominio.Properties;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Dominio.Servicios.Impl
{
    class RedisDb
    {
        IDatabase database;
        public RedisDb()
        {
            ConnectionMultiplexer conn = ConnectionMultiplexer.Connect(Resources.RedsConnection);
            database = conn.GetDatabase();
        }

        public async Task RegisterAsync<T>(string cacheKey, T value, TimeSpan expire)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(value);
            await database.StringSetAsync(cacheKey, json, expire);
        }

        public async Task<T> GetAsync<T>(string cacheKey)
        {
            var data = await database.StringGetAsync(cacheKey);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(data);
        }
    }
}
