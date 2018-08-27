using CieloEcommerce;
using Newtonsoft.Json;
using PaymentGateway.DataContracts.Dto;
using PaymentGateway.DataContracts.LocalDb;
using PaymentGateway.Interfaces;
using PaymentGateway.Unity;
using StonePaymentGateway;
using StonePaymentGateway.DataContracts;
using StonePaymentGateway.DataContracts.EnumTypes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;

namespace PaymentGateway.Services
{
    public class PaymentService : AbstractService, IPaymentService
    {
        private readonly IStoreDal _storeDal;
        private readonly IMockClearSaleDal _mockClearSaleDal;
        private readonly IPaymentDal _paymentDal;
        private readonly IPaymentBll _paymentBll;
        private readonly PaymentRequest _paymentRequest;
        public PaymentService(IContainerIoc pContainer)
            : base(pContainer)
        {
            _storeDal = AbstractUnityConfig.Resolve<IStoreDal>();
            _mockClearSaleDal = AbstractUnityConfig.Resolve<IMockClearSaleDal>();
            _paymentDal = AbstractUnityConfig.Resolve<IPaymentDal>();
            _paymentBll = AbstractUnityConfig.Resolve<IPaymentBll>();
        }
        public PaymentService(IStoreDal pStoreDal)
        {
            _storeDal = pStoreDal;
        }


        public DataContracts.Dto.BaseResponse Payment(PaymentRequest pPaymentRequest)
        {
            var response = new DataContracts.Dto.BaseResponse();

            try
            {
                var store =_storeDal.GetStoreById(new GetStore { Id = pPaymentRequest.IdStore, IsTest = pPaymentRequest.IsTest });
                _paymentBll.StoreValidate(store);
                var lCreditCards = _mockClearSaleDal.GetCredCards();
                _paymentBll.ClearSaleValidate(pPaymentRequest, lCreditCards);
                IList<RelStoreAcquirer> lRelStoreAcquirer = new List<RelStoreAcquirer>();
                IList<Acquirer> lAcquirer = new List<Acquirer>();
                lRelStoreAcquirer = store.RelStoreAcquirer.ToList();

                foreach (var acquirer in lRelStoreAcquirer)
                {
                    lAcquirer.Add(acquirer.Acquirer);
                }

                var transaction = ChooseAcquirer(pPaymentRequest, lAcquirer);
                transaction.IsTest = pPaymentRequest.IsTest;
                _paymentDal.SaveTransaction(transaction);
            }
            catch (Exception ex)
            {
                HandleException(ex, response);
            }

            return response;
        }


        private DataContracts.LocalDb.Transaction ChooseAcquirer(PaymentRequest pPaymentRequest, IList<Acquirer> plAcquirer)
        {
            if(pPaymentRequest.CreditCardBrand.Equals(1))
            {
                return StonePayment(pPaymentRequest, plAcquirer.Where(ac => ac.Name.Equals("Stone")).FirstOrDefault());
            }
            else if (pPaymentRequest.CreditCardBrand.Equals(2))
            {
                return CieloPayment(pPaymentRequest, plAcquirer.Where(ac => ac.Name.Equals("Cielo")).FirstOrDefault());
            }

            return null;
        }

        private DataContracts.LocalDb.Transaction StonePayment(PaymentRequest pPaymentRequest, Acquirer pAcquirer)
        {
            //Create transaction.
            var transaction = new CreditCardTransaction()
            {
                AmountInCents = 10000,
                CreditCard = new CreditCard()
                {
                    CreditCardBrand = CreditCardBrandEnum.Mastercard,
                    CreditCardNumber = pPaymentRequest.CreditCardNumber,
                    ExpMonth = Convert.ToInt32(pPaymentRequest.ExpMonth),
                    ExpYear = Convert.ToInt32(pPaymentRequest.ExpYear),
                    HolderName = pPaymentRequest.HolderName,
                    SecurityCode = pPaymentRequest.SecurityCode
                },
                InstallmentCount = 1,
                Options = new CreditCardTransactionOptions { PaymentMethodCode = 1 }
            };

            //Create request.
            var createSaleRequest = new CreateSaleRequest()
            {
                // Adiciona a transação na requisição.
                CreditCardTransactionCollection = new Collection<CreditCardTransaction>(new CreditCardTransaction[] { transaction }),
                Order = new StonePaymentGateway.DataContracts.Order()
                {
                    OrderReference = "Simulador"
                }
            };

            Guid merchantKey = Guid.Parse(pAcquirer.MerchanteKey);
            var serviceClient = new GatewayServiceClient(merchantKey, new Uri("https://transaction.stone.com.br"));
            var httpResponse = serviceClient.Sale.Create(createSaleRequest);
            var result = httpResponse.Response.CreditCardTransactionResultCollection.FirstOrDefault();
            var transactionDb = new DataContracts.LocalDb.Transaction();

            transactionDb.Authorization = result.AuthorizationCode;
            transactionDb.AuthAmountInCents = result.AuthorizedAmountInCents.ToString();
            transactionDb.CardExpiration = pPaymentRequest.ExpYear + pPaymentRequest.ExpMonth;
            transactionDb.CardNumber = pPaymentRequest.CreditCardNumber;
            transactionDb.Date = (DateTime)result.CapturedDate;
            transactionDb.MerchanteKey = pAcquirer.MerchanteKey;
            transactionDb.Message = result.AcquirerMessage;
            transactionDb.CardName = pPaymentRequest.HolderName;
            transactionDb.CardSecurityCode = pPaymentRequest.SecurityCode;
            
            return transactionDb;
        }

        private DataContracts.LocalDb.Transaction CieloPayment(PaymentRequest pPaymentRequest, Acquirer pAcquirer)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var cielo = new Cielo("1006993069", pAcquirer.MerchanteKey, Cielo.TEST);

            var holder = cielo.holder(pPaymentRequest.CreditCardNumber, pPaymentRequest.ExpYear, pPaymentRequest.ExpMonth, pPaymentRequest.SecurityCode);
            holder.name = "Fulano Portador da Silva";

            var randomOrder = new Random();

            var order = cielo.order(randomOrder.Next(1000, 10000).ToString(), 10000);
            var paymentMethod = cielo.paymentMethod(PaymentMethod.VISA, PaymentMethod.CREDITO_A_VISTA);

            var transaction = cielo.transactionRequest(
                holder,
                order,
                paymentMethod,
                "http://localhost/cielo",
                CieloEcommerce.Transaction.AuthorizationMethod.AUTHORIZE_WITHOUT_AUTHENTICATION,
                false
            );

            var transactionDb = new DataContracts.LocalDb.Transaction();
            transactionDb.Authorization = transaction.authorization.code.ToString();
            transactionDb.AuthAmountInCents = transaction.order.total.ToString();
            transactionDb.CardExpiration = pPaymentRequest.ExpYear + pPaymentRequest.ExpMonth;
            transactionDb.CardNumber = pPaymentRequest.CreditCardNumber;
            transactionDb.Date = Convert.ToDateTime(transaction.authorization.dateTime);
            transactionDb.MerchanteKey = pAcquirer.MerchanteKey;
            transactionDb.Message = transaction.authentication.message;
            transactionDb.CardName = pPaymentRequest.HolderName;
            transactionDb.CardSecurityCode = pPaymentRequest.SecurityCode;

            return transactionDb;
        }
    }
}
