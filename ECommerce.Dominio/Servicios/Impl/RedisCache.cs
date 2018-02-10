using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Dominio.Servicios.Impl
{
    class RedisCache : ICache
    {
        RedisDb db;
        public RedisCache(RedisDb db)
        {
            this.db = db;
        }

        public Task GetAsync<T>(string cacheKey)
        {
            return db.GetAsync<T>(cacheKey);
        }

        public Task RegisterAsync<T>(string cacheKey, T value, TimeSpan expire)
        {
            return db.RegisterAsync(cacheKey, value, expire);
        }
    }
}
