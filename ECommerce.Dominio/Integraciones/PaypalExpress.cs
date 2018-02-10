using PaypalWebService;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Dominio.Integraciones
{
    class PaypalExpress
    {
        private const string PAYPALUSER = "lorenkid-facilitator_api1.gmail.com";
        private const string PAYPALSIGNATURE = "AFcWxV21C7fd0v3bYYYRCpSSRl31A8IEKzCBjnvoewQhZOeuxXoEEfyc";
        private const string PAYPALPASSWORD = "G5XCF5E7MUK5K95D";
        private const string PAYPALURLCHECKOUT = "";

        CustomSecurityHeaderType GetAuthorizationRequest()
        {
            return new CustomSecurityHeaderType()
            {
                Credentials = new UserIdPasswordType()
                {
                    Signature = PAYPALSIGNATURE,
                    Password = PAYPALPASSWORD,
                    Username = PAYPALUSER,

                }
            };
        }
        public async Task<string> SetExpressCheckoutAsync(SetExpressCheckoutReq request, bool recordarDatos = false)
        {
            PayPalAPIAAInterfaceClient client = new PayPalAPIAAInterfaceClient();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var response = await client.SetExpressCheckoutAsync(GetAuthorizationRequest(), request);
            if (response.SetExpressCheckoutResponse1.Ack == AckCodeType.Success)
                return string.Format(PAYPALURLCHECKOUT, response.SetExpressCheckoutResponse1.Token);
            throw new ResponseException("Not correct");
        }

        public async Task<AckCodeType> DoExpressCheckoutAsync(DoExpressCheckoutPaymentReq request)
        {
            PayPalAPIAAInterfaceClient client = new PayPalAPIAAInterfaceClient();
            var response = await client.DoExpressCheckoutPaymentAsync(GetAuthorizationRequest(), request);
            return response.DoExpressCheckoutPaymentResponse1.Ack;
            
        }

        public async Task<AckCodeType> CreateBillingAgreementAsync(CreateBillingAgreementReq request)
        {
            PayPalAPIAAInterfaceClient client = new PayPalAPIAAInterfaceClient();
            var response = await client.CreateBillingAgreementAsync(GetAuthorizationRequest(), request);
            return response.CreateBillingAgreementResponse1.Ack;
        }

        public async Task<AckCodeType> CreateRecurringPaymentsProfileAsync(CreateRecurringPaymentsProfileReq request)
        {
            PayPalAPIAAInterfaceClient client = new PayPalAPIAAInterfaceClient();
            var response = await client.CreateRecurringPaymentsProfileAsync(GetAuthorizationRequest(), request);
            return response.CreateRecurringPaymentsProfileResponse1.Ack;
            
        }
    }

    class ResponseException : Exception
    {
        public ResponseException(string msg)
        {

        }
    }
}
