using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Dominio.Requests
{
    public class RegistroPedido
    {
        public int ClienteId { get; set; }
        public ICollection<int> Productos { get; set; }
    }
}
