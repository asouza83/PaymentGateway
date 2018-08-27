using PaymentGateway.CustomExceptions;
using PaymentGateway.DataContracts.CreditCardTransaction;
using PaymentGateway.DataContracts.Dto;
using PaymentGateway.DataContracts.LocalDb;
using PaymentGateway.Interfaces;
using PaymentGateway.Unity;
using System.Collections.Generic;
using System.Linq;

namespace PaymentGateway.Bll
{
    public class PaymentBll : IPaymentBll
    {
        public PaymentBll(IContainerIoc pContainer)
        {
        }
        public void StoreValidate(Store pStore)
        {
            if (pStore == null)
                throw new BllException("Invalid Store!");

        }

        public string ClearSaleValidate(PaymentRequest pPaymentRequest, IList<CreditCard> plCreditCards)
        {
            var creditCard = plCreditCards.FirstOrDefault(c => c.CreditCardNumber.Equals(pPaymentRequest.CreditCardNumber));
            if (string.IsNullOrWhiteSpace(pPaymentRequest.CreditCardNumber) && pPaymentRequest.CreditCardNumber.Equals(creditCard.CreditCardNumber)
                && pPaymentRequest.ExpMonth.Equals(creditCard.ExpMonth)
                && pPaymentRequest.ExpYear.Equals(creditCard.ExpYear)
                && pPaymentRequest.SecurityCode.Equals(creditCard.SecurityCode)
                )
            {
                throw new BllException("Denied!");
            }
            else { return "APA"; }
        }
    }
}
