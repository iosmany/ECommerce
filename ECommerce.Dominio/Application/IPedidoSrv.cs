using ECommerce.Dominio.DTOs;
using ECommerce.Dominio.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Dominio.Application
{
    public interface IPedidoSrv
    {
        Task<PedidoDTO> RegistraAsync(RegistroPedido request);
        Task<string> SetExpressCheckoutAsync(PaymentRequest request);
        Task DoExpressCheckoutAsync(DoExpressCheckoutRequest request);
    }
}
