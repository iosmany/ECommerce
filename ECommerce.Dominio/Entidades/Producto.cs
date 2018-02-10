using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ECommerce.Dominio.Entidades
{
    [Table("Productos")]
    class Producto
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, StringLength(150)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        [Column("Pedido"), ForeignKey("FK_Producto_Pedido")]
        public int PedidoId { get; set; }
        public Pedido Pedido { get; internal set; }
    }
}
