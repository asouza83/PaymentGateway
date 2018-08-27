using System;
using Unity;

namespace PaymentGateway.Unity
{
    public delegate void RegisterTypesDelegate(IUnityContainer container);
    public class AbstractUnityConfig
    {
        #region Public Methods

        public static void RegisterType<T1, T2>(string pAlias = "", bool pSingleton = false) where T2 : T1
        {
            if (!String.IsNullOrEmpty(pAlias))
            {
                ContainerIoc.RegisterType<T1, T2>(pAlias, pSingleton);
            }
            else
            {
                ContainerIoc.RegisterType<T1, T2>(pSingleton);
            }
        }

        public static void RegisterType<T1, T2>(bool pUsaParametros, string pAlias = "", bool pSingleton = false, params object[] parameterValues) where T2 : T1
        {
            if (!String.IsNullOrEmpty(pAlias))
            {
                ContainerIoc.RegisterType<T1, T2>(pAlias, pUsaParametros, pSingleton: pSingleton, parameterValues: parameterValues);
            }
            else
            {
                ContainerIoc.RegisterType<T1, T2>(pUsaParametros, pSingleton: pSingleton, parameterValues: parameterValues);
            }
        }

        public static void RegisterType<T1, T2>(bool pUsaParametros, string pAlias = "", bool pSingleton = false, bool pInjetaContainer = true, params object[] parameterValues) where T2 : T1
        {
            if (!String.IsNullOrEmpty(pAlias))
            {
                ContainerIoc.RegisterType<T1, T2>(pUsaParametros, pSingleton, pInjetaContainer, parameterValues);
            }
            else
            {
                ContainerIoc.RegisterType<T1, T2>(pAlias, pUsaParametros, pSingleton, pInjetaContainer, parameterValues);
            }
        }

        public static T Resolve<T>()
        {
            return Resolve<T>(String.Empty);
        }

        public static T Resolve<T>(string alias)
        {
            if (!String.IsNullOrEmpty(alias))
            {
                return GetConfiguredContainer().Resolve<T>(alias);
            }
            else
            {
                return GetConfiguredContainer().Resolve<T>();
            }
        }

        #endregion

        #region Protected Methods

        protected static void ConfiguraUnityConfig(RegisterTypesDelegate pRegisterTypesDelegate)
        {
            _container = new Lazy<IUnityContainer>(() =>
            {
                var container = new UnityContainer();
                ContainerIoc = new ContainerUnity(container);

                if (RegisterTypesDelegate != null)
                {
                    RegisterTypesDelegate.Invoke(container);
                }
                else
                {
                    throw new ArgumentException("O método RegisterTypes não foi configurado e/ou chamado corretamente, verifique se o método ConfiguraUnityConfig foi chamado passando o método de registro de tipos por delegate");
                }

                return container;
            });
            RegisterTypesDelegate = pRegisterTypesDelegate;
        }

        #endregion

        #region Private Fields

        private static Lazy<IUnityContainer> _container;

        #endregion

        #region Private Properties

        private static IContainerIoc ContainerIoc { get; set; }
        private static RegisterTypesDelegate RegisterTypesDelegate { get; set; }

        #endregion

        #region Private Methods

        private static IUnityContainer GetConfiguredContainer()
        {
            return _container.Value;
        }

        #endregion
    }
}
