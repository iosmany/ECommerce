using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Dominio.Application.Impl;
using ECommerce.Dominio.Servicios;
using ECommerce.Dominio.Properties;
using ECommerce.Dominio.Servicios.Impl;

namespace ECommerce.Dominio.Application
{
    public class IoCBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IClienteSrv>().To<ClienteSrv>().InSingletonScope();
            Bind<IPedidoSrv>().To<PedidoSrv>().InSingletonScope();
            Bind<RedisDb>().ToSelf().InSingletonScope();
            Bind<ICache>().To(CacheResolution()).InSingletonScope();
        }

        Type CacheResolution()
        {
            string tipo = Resources.TipoCache;
            if (tipo == "redis")
                return typeof(RedisCache);
            return typeof(MemoryCache);

        }
    }
}
