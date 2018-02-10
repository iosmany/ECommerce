using ECommerce.Dominio.DTOs;
using ECommerce.Dominio.Entidades;
using ECommerce.Dominio.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Dominio.Repositorios
{
    static class ClaimRepository
    {
        public static PedidoDTO BuildDTO(this Pedido pedido)
        {
            return AutoMapper.Mapper.Map<PedidoDTO>(pedido);
        }

        public static Pedido ToEntity(this RegistroPedido request)
        {
            return AutoMapper.Mapper.Map<Pedido>(request);
        }
    }
}
