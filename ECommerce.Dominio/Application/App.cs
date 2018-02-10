using ECommerce.Dominio.MapperRegisters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;
using AutoMapper.Configuration;
using AutoMapper;
using Ninject;

namespace ECommerce.Dominio.Application
{
    public static class App
    {
        internal static ECommerceContext GetContext() => new ECommerceContext();
        internal static ECommerceContext GetReadOnlyContext() => new ECommerceContext();
        static Func<Assembly, IEnumerable<IMapperRegister>> mapRegisters = (assembly)
            => assembly.GetTypes().Where(t => t.GetInterface(nameof(IMapperRegister)) != null).Select(x => (IMapperRegister)Activator.CreateInstance(x));

        static App()
        {
        }

        /// <summary>
        /// Inicializa aplicación
        /// </summary>
        public static void Init()
        {
            ContainerInit();
            CreateMappers();
            InitializeDB();
        }
        static void InitializeDB()
        {
            using (ECommerceContext ctx = new ECommerceContext())
            {
                ctx.Database.EnsureCreated();
            }
        }
        static void CreateMappers()
        {
            MapperConfigurationExpression cfg = new MapperConfigurationExpression();
            foreach (var mapper in mapRegisters(Assembly.GetCallingAssembly()))
                mapper.CreateRegistries(cfg);
            Mapper.Initialize(cfg);
            Mapper.Configuration.AssertConfigurationIsValid();
        }
        /// <summary>
        /// IoC Container
        /// </summary>
        static StandardKernel container;
        static IKernel Container
        {
            get
            {
                if (container == null)
                    ContainerInit();
                return container;
            }
        }
        static void ContainerInit()
        {
            container = new StandardKernel();
            container.Load(Assembly.GetCallingAssembly());
        }
        public static T GetInstance<T>()
        {
            return Container.Get<T>();
        }
    }
}
