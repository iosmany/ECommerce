using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Dominio.Servicios.Impl
{
    class MemoryCache : ICache
    {
        public Task GetAsync<T>(string cacheKey)
        {
            throw new NotImplementedException();
        }

        public Task RegisterAsync<T>(string cacheKey, T value, TimeSpan expire)
        {
            throw new NotImplementedException();
        }
    }
}
