using PaymentGateway.DataContracts.CreditCardTransaction;
using PaymentGateway.DataContracts.Dto;
using PaymentGateway.DataContracts.LocalDb;
using System.Collections.Generic;

namespace PaymentGateway.Interfaces
{
    public interface IPaymentBll
    {
        void StoreValidate(Store pStore);
        string ClearSaleValidate(PaymentRequest pPaymentRequest, IList<CreditCard> plCreditCards);
    }
}
