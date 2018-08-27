using PaymentGateway.DataContracts.CreditCardTransaction;
using PaymentGateway.Interfaces;
using PaymentGateway.Unity;
using System.Collections.Generic;

namespace PaymentGateway.Dal.Mocks
{
    public class MockClearSaleDal : AbstractDal, IMockClearSaleDal
    {
        public MockClearSaleDal(IContainerIoc container)
        : base(container)
        { }
        public IList<CreditCard> GetCredCards()
        {
            var credCard01 = new CreditCard
            {
                CreditCardNumber = "4111111111111111",
                ExpMonth = 10,
                ExpYear = 22,
                HolderName = "LUKE SKYWALKER",
                SecurityCode = "1283"
            };

            var lCreditCard = new List<CreditCard>();
            lCreditCard.Add(credCard01);

            return lCreditCard;
        }
    }
}
