using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ECommerce.Dominio.Entidades
{
    [Table("Clientes")]
    class Cliente
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, StringLength(250)]
        public string Email { get; set; }
        public byte[] Password { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; }
        [StringLength(200)]
        public string LastName { get; set; }
        public string PaypalAgreementId { get; set; }
        public ICollection<Pedido> Pedidos { get; set; }
    }
}
