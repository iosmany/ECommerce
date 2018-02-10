using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Dominio.MapperRegisters
{
    interface IMapperRegister
    {
        void CreateRegistries(IMapperConfigurationExpression cfg);
    }
}
