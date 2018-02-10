using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ECommerce.Dominio.Entidades
{
    [Table("Pedidos")]
    class Pedido
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string TransactionId { get; set; }
        public EstadoPedido Estado { get; set; }
        public decimal Descuento { get; set; }
        public decimal Bruto { get; set; }
        public decimal Total { get; set; }
        public string Telefono { get; set; }
        [Column("Cliente")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
