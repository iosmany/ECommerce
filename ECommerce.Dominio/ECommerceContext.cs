using ECommerce.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Dominio
{
    class ECommerceContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ECommerceDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().HasMany(x => x.Pedidos).WithOne(x => x.Cliente);
            modelBuilder.Entity<Pedido>().HasIndex(x => x.ClienteId);
            modelBuilder.Entity<Pedido>().HasMany(x => x.Productos).WithOne(x => x.Pedido);
        }

    }
}
