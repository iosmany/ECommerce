using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Dominio.DTOs
{
    public class PedidoDTO
    {
        public int Id { get; set; }
        public string TransactionId { get; set; }
        public decimal Descuento { get; set; }
        public decimal Bruto { get; set; }
        public decimal Total { get; set; }
        public string Telefono { get; set; }
        public string ClientFullName { get; set; }
        public IReadOnlyCollection<ProductoDTO> Productos { get; set; }
    }
}
