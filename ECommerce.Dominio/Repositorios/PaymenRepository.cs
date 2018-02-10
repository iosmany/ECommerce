using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ECommerce.Dominio.Entidades;
using ECommerce.Dominio.Requests;
using PaypalWebService;

namespace ECommerce.Dominio.Repositorios
{
    static class PaymenRepository
    {
        public static SetExpressCheckoutReq GetSetExpressCheckoutRequest(this PaymentRequest request, Pedido pedido)
        {
            //create payments tuples
            ICollection<PaymentDetailsType> payments = new List<PaymentDetailsType>();
            foreach (var product in pedido.Productos)
            {
                string amount = pedido.Total.ToString();
                payments.Add(new PaymentDetailsType()
                {
                    OrderTotal = new BasicAmountType() { currencyID = CurrencyCodeType.EUR, Value = amount },
                    PaymentDetailsItem = new PaymentDetailsItemType[]
                    {
                        new PaymentDetailsItemType(){ Name = product.Name, Description = "Una descripcion", Quantity = "1",
                                        Amount = new BasicAmountType() { currencyID = CurrencyCodeType.EUR, Value = amount } }
                    },
                    InvoiceID = pedido.TransactionId
                });
            }

            return new SetExpressCheckoutReq()
            {
                SetExpressCheckoutRequest = new SetExpressCheckoutRequestType()
                {
                    SetExpressCheckoutRequestDetails = new SetExpressCheckoutRequestDetailsType()
                    {
                        PaymentDetails = payments.ToArray(),
                        ReturnURL = request.UrlOk,
                        CancelURL = request.UrlKo,
                        PaymentAction = PaymentActionCodeType.Sale
                    },
                    Version = "106.0"
                }
            };
        }
        public static DoExpressCheckoutPaymentReq GetDoExpressCheckoutRequest(this DoExpressCheckoutRequest request)
        {
            return AutoMapper.Mapper.Map<DoExpressCheckoutPaymentReq>(request);
        }
    }
}
