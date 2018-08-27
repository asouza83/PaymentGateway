using StonePaymentGateway.DataContracts;
using StonePaymentGateway.DataContracts.EnumTypes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PaymentGateway.Mocks
{
    public class StoneMocks
    {
        public CreateSaleResponse ValidatePaymentSuccessfully()
        {
            var createSaleResponse = new CreateSaleResponse();

            createSaleResponse.InternalTime = 268;
            createSaleResponse.MerchantKey = new Guid("f2a1f485-cfd4-49f5-8862-0ebc438ae923");
            createSaleResponse.RequestKey = new Guid("35729062-b579-4aea-af2d-f98f91b6df27");

            var creditCardTransactionResult = new CreditCardTransactionResult();
            creditCardTransactionResult.AcquirerMessage = "Mock|Transação de simulação autorizada com sucesso";
            creditCardTransactionResult.AcquirerName = "Mock";
            creditCardTransactionResult.AcquirerReturnCode = "0";
            creditCardTransactionResult.AmountInCents = 10000;
            creditCardTransactionResult.AuthorizationCode = "487095";
            creditCardTransactionResult.AuthorizedAmountInCents = 10000;
            creditCardTransactionResult.CapturedAmountInCents = 10000;
            creditCardTransactionResult.CapturedDate = DateTime.Now;
            creditCardTransactionResult.CreditCard = new CreditCardData();
            creditCardTransactionResult.CreditCard.CreditCardBrand = CreditCardBrandEnum.Visa;
            creditCardTransactionResult.CreditCard.InstantBuyKey = new Guid("b7f8e013-7245-4b23-a7b9-8d9890adb46a");
            creditCardTransactionResult.CreditCard.IsExpiredCreditCard = false;
            creditCardTransactionResult.CreditCard.MaskedCreditCardNumber = "411111****1111";
            creditCardTransactionResult.CreditCardOperation = CreditCardOperationEnum.AuthAndCapture;
            creditCardTransactionResult.CreditCardTransactionStatus = CreditCardTransactionStatusEnum.Captured;
            creditCardTransactionResult.ExternalTime = 0;
            creditCardTransactionResult.PaymentMethodName = "Mock";
            creditCardTransactionResult.Success = true;
            creditCardTransactionResult.TransactionIdentifier = "153830";
            creditCardTransactionResult.TransactionKey = new Guid("7729f941-3d30-4ccc-af14-b54c8a60fe47");
            creditCardTransactionResult.TransactionKeyToAcquirer = "6a13137f8e784748";
            creditCardTransactionResult.TransactionReference = "ef21a347-d151-4894-911c-833eb01b3c0f";
            creditCardTransactionResult.UniqueSequentialNumber = "240396";

            createSaleResponse.CreditCardTransactionResultCollection = new Collection<CreditCardTransactionResult>();
            createSaleResponse.CreditCardTransactionResultCollection.Add(creditCardTransactionResult);

            createSaleResponse.OrderResult = new OrderResult();
            createSaleResponse.OrderResult.CreateDate = DateTime.Now;
            createSaleResponse.OrderResult.OrderKey = new Guid("c5f5ea13-1bb1-4737-9f9f-28cf56350e0f");
            createSaleResponse.OrderResult.OrderReference = "NumeroDoPedido";

            return createSaleResponse;
        }

        public IList<CreditCard> GetAllCreditCards()
        {
            var CrediCard01 = new CreditCard();
            CrediCard01.CreditCardBrand = CreditCardBrandEnum.Visa;
            CrediCard01.CreditCardNumber = "9999999999999999";
            CrediCard01.ExpMonth = 07;
            CrediCard01.ExpYear = 99;
            CrediCard01.HolderName = "ALEXANDRE SOUZA";
            CrediCard01.SecurityCode = "777";

            var CrediCard02 = new CreditCard();
            CrediCard02.CreditCardBrand = CreditCardBrandEnum.Visa;
            CrediCard02.CreditCardNumber = "4111111111111111";
            CrediCard02.ExpMonth = 10;
            CrediCard02.ExpYear = 22;
            CrediCard02.HolderName = "LUKE SKYWALKER";
            CrediCard02.SecurityCode = "123";

            var lCreditCards = new List<CreditCard>();
            lCreditCards.Add(CrediCard01);
            lCreditCards.Add(CrediCard02);

            return lCreditCards;
        }
    }
}
