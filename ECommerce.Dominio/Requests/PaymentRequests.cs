using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Dominio.Requests
{
    public class PaymentRequest
    {
        public string UrlOk { get; set; }
        public string UrlKo { get; set; }

        public string CreditCard { get; set; }
        public string Titular { get; set; }
        public string Cvvn { get; set; }
        public string CardType { get; set; }

        public int ClienteId { get; set; }
    }

    public class PaymentRequestBuilder
    {
        public string UrlOk { get; set; }
        public string UrlKo { get; set; }

        public string CreditCard { get; set; }
        public string Titular { get; set; }
        public string Cvvn { get; set; }
        public string CardType { get; set; }

        public int ClienteId { get; set; }
    }

    public class DoExpressCheckoutRequest
    {
        public string PayerId { get; set; }
        public string Token { get; set; }
    }
}
