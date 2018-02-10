using ECommerce.Dominio.DTOs;
using ECommerce.Dominio.Requests;
using ECommerce.Dominio.Servicios;
using Ninject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Dominio.Application.Impl
{
    class ClienteSrv: IClienteSrv
    {
        ICache cache;

        [Inject]
        public ClienteSrv(ICache cache)
        {
            this.cache = cache;
        }

        public Task<LoginDTO> LoginAsync(LoginRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ClienteDTO> RegistroAsync(ClientRegister request)
        {
            throw new NotImplementedException();
        }
    }
}
