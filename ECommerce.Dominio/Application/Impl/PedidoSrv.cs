using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Dominio.DTOs;
using ECommerce.Dominio.Entidades;
using ECommerce.Dominio.Integraciones;
using ECommerce.Dominio.Repositorios;
using ECommerce.Dominio.Requests;
using ECommerce.Dominio.Servicios;

namespace ECommerce.Dominio.Application.Impl
{
    class PedidoSrv : IPedidoSrv
    {
        ICache cache;

        public PedidoSrv(ICache cache)
        {
            this.cache = cache;
        }

        public async Task<PedidoDTO> RegistraAsync(RegistroPedido request)
        {
            using (ECommerceContext ctx = App.GetContext())
            {
                var pedido = request.ToEntity();
                ctx.Pedidos.Add(pedido);
                await ctx.SaveChangesAsync();
                return pedido.BuildDTO();
            }
        }

        public async Task<string> SetExpressCheckoutAsync(PaymentRequest request)
        {
            PaypalExpress paypal = new PaypalExpress();
            using (var ctx = App.GetReadOnlyContext())
            {
                var pedido = ctx.Pedidos.Where(x=>x.Estado == EstadoPedido.Pendiente).FirstOrDefault(x=>x.ClienteId == request.ClienteId);
                if (pedido == null)
                    throw new ArgumentNullException("No existe pedido pendiente de pago para cliente");
                return await paypal.SetExpressCheckoutAsync(request.GetSetExpressCheckoutRequest(pedido));
            }
        }

        public Task DoExpressCheckoutAsync(DoExpressCheckoutRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
