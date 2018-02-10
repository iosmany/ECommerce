using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Dominio.Servicios
{
    public interface ICache
    {
        Task RegisterAsync<T>(string cacheKey, T value, TimeSpan expire);
        Task GetAsync<T>(string cacheKey);
    }
}
