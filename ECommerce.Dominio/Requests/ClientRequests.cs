using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ECommerce.Dominio.Requests
{
    public class ClientRegister
    {
        [Required, StringLength(250)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required, Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; }
        [StringLength(200)]
        public string LastName { get; set; }

        internal byte[] CodificaPassword()
        {
            string cod = Convert.ToBase64String(Encoding.UTF8.GetBytes(Password));
            return Encoding.UTF8.GetBytes(cod);
        }
    }

    public class LoginRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
