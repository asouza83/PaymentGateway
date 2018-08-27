using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentGateway.Api.App_Start;
using PaymentGateway.DataContracts.Dto;
using PaymentGateway.Interfaces;
using PaymentGateway.Unity;

namespace PaymentGatewayApi.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidCreditCard()
        {
            UnityConfig.Inicializar();
            var paymentRequest = new PaymentRequest();
            paymentRequest.IdStore = 1;
            paymentRequest.CreditCardBrand = 1;
            paymentRequest.CreditCardNumber = "4111111111111111";
            paymentRequest.ExpMonth = "10";
            paymentRequest.ExpYear = "22";
            paymentRequest.SecurityCode = "123";
            paymentRequest.HolderName = "LUKE SKYWALKER";
            paymentRequest.IsTest = true;

            var paymentService = AbstractUnityConfig.Resolve<IPaymentService>();
            var result = paymentService.Payment(paymentRequest);
            Assert.IsTrue(result.Success);
        }

        [TestMethod]
        public void InvalidCreditCard()
        {
            UnityConfig.Inicializar();
            var paymentRequest = new PaymentRequest();
            paymentRequest.IdStore = 1;
            paymentRequest.CreditCardBrand = 1;
            paymentRequest.CreditCardNumber = "4111111111111111";
            paymentRequest.ExpMonth = "10asd";
            paymentRequest.ExpYear = "22";
            paymentRequest.SecurityCode = "123";
            paymentRequest.HolderName = "LUKE SKYWALKER";
            paymentRequest.IsTest = true;

            var paymentService = AbstractUnityConfig.Resolve<IPaymentService>();
            var result = paymentService.Payment(paymentRequest);
            Assert.IsTrue(!result.Success);
        }
    }
}
