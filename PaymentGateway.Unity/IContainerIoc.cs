using System.Data.Common;

namespace PaymentGateway.Unity
{
    public interface IContainerIoc
    {
        #region Public Properties

        DbTransaction Transaction { get; set; }

        #endregion

        #region Public Methods

        void RegisterType<TFrom, TTo>(bool pSingleton = false) where TTo : TFrom;

        void RegisterType<TFrom, TTo>(string pAlias, bool pSingleton = false) where TTo : TFrom;

        void RegisterType<TFrom, TTo>(string pAliais, bool pUsaParametros, bool pSingleton = false, bool pInjetaContainer = true, params object[] parameterValues) where TTo : TFrom;

        void RegisterType<TFrom, TTo>(bool pUsaParametros, bool pSingleton = false, bool pInjetaContainer = true, params object[] parameterValues) where TTo : TFrom;

        T Resolve<T>(string key = "");

        #endregion
    }
}
