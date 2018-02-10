using ECommerce.Dominio.DTOs;
using ECommerce.Dominio.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Dominio.Application
{
    public interface IClienteSrv
    {
        Task<ClienteDTO> RegistroAsync(ClientRegister request);
        Task<LoginDTO> LoginAsync(LoginRequest request);
    }
}
