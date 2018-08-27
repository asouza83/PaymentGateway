using PaymentGateway.DataContracts.CreditCardTransaction;
using System.Collections.Generic;

namespace PaymentGateway.Interfaces
{
    public interface IMockClearSaleDal
    {
        IList<CreditCard> GetCredCards();
    }
}
