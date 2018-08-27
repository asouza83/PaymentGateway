using PaymentGateway.Bll;
using PaymentGateway.Dal;
using PaymentGateway.Dal.Mocks;
using PaymentGateway.Interfaces;
using PaymentGateway.Services;
using PaymentGateway.Unity;
using Unity;

namespace PaymentGateway.Api.App_Start
{
    public class UnityConfig : AbstractUnityConfig
    {
        #region Public Methods

        public static void Inicializar()
        {
            ConfiguraUnityConfig(RegisterTypes);
        }

        #endregion

        #region Private Methods

        private static void RegisterTypes(IUnityContainer container)
        {
            IContainerIoc oContainer = new ContainerUnity(container);
            //Dals
            oContainer.RegisterType<IStoreDal, StoreDal>();
            oContainer.RegisterType<IPaymentDal, PaymentDal>();
            oContainer.RegisterType<IMockClearSaleDal, MockClearSaleDal>();

            //Blls
            oContainer.RegisterType<IPaymentBll, PaymentBll>();

            //Services
            oContainer.RegisterType<IPaymentService, PaymentService>();
            
        }

        #endregion
    }
}
