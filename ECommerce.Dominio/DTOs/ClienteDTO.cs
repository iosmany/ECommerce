using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Dominio.DTOs
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PaypalAgreementId { get; set; }
        public ICollection<PedidoDTO> Pedidos { get; set; }
    }

    public class LoginDTO
    {
        public ClienteDTO Cuenta { get; set; }
        public string Token { get; set; }
    }
}
