using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ECommerce.Dominio.DTOs;
using ECommerce.Dominio.Entidades;
using ECommerce.Dominio.Requests;
using PaypalWebService;

namespace ECommerce.Dominio.MapperRegisters.Impl
{
    class MapperRegistries : IMapperRegister
    {
        public void CreateRegistries(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Cliente, ClienteDTO>();
            cfg.CreateMap<ClientRegister, Cliente>()
                .ForMember(d => d.Password, o => o.MapFrom(s => s.CodificaPassword()))
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.PaypalAgreementId, o => o.Ignore())
                .ForMember(d => d.Pedidos, o => o.Ignore());
            cfg.CreateMap<Pedido, PedidoDTO>()
                .ForMember(d => d.ClientFullName, o => o.MapFrom(s => $"{s.Cliente.Name} {s.Cliente.LastName}"));
            cfg.CreateMap<Producto, ProductoDTO>();
            //cfg.CreateMap<DoExpressCheckoutRequest, DoExpressCheckoutPaymentReq>();
        }
    }
}
