using PaymentGateway.Unity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace PaymentGateway.Unity
{
    public class ContainerUnity : IContainerIoc
    {
        #region Public Constructors

        public ContainerUnity()
        {
            _container = new UnityContainer();
            //_container.LoadConfiguration();
        }

        public ContainerUnity(IUnityContainer pContainer)
        {
            _container = pContainer;
        }

        #endregion

        #region Public Properties

        public DbTransaction Transaction
        {
            get { return _transaction; }
            set { _transaction = value; }
        }

        #endregion

        #region Public Methods

        public void RegisterType<TFrom, TTo>(bool pSingleton = false) where TTo : TFrom
        {
            if (pSingleton)
            {
                _container.RegisterType<TFrom, TTo>(new PerThreadLifetimeManager(), new InjectionConstructor(this));
            }
            else
            {
                _container.RegisterType<TFrom, TTo>(new InjectionConstructor(this));
            }
        }

        public void RegisterType<TFrom, TTo>(string pAlias, bool pSingleton = false) where TTo : TFrom
        {
            if (pSingleton)
            {
                _container.RegisterType<TFrom, TTo>(pAlias, new PerThreadLifetimeManager(), new InjectionConstructor(this));
            }
            else
            {
                _container.RegisterType<TFrom, TTo>(pAlias, new InjectionConstructor(this));
            }
        }

        public void RegisterType<TFrom, TTo>(bool pUsaParametros, bool pSingleton = false, bool pInjetaContainer = true, params object[] parameterValues) where TTo : TFrom
        {
            var lParameter = new List<InjectionParameter>();
            if (pUsaParametros)
            {
                lParameter.AddRange(from param in parameterValues let type = param.GetType() select new InjectionParameter(type, param));
            }

            if (pInjetaContainer)
            {
                lParameter.Add(new InjectionParameter(this));
            }

            var injectionConstructor =
                new InjectionConstructor(lParameter.ToArray());

            if (pSingleton)
            {
                _container.RegisterType<TFrom, TTo>(new PerThreadLifetimeManager(), injectionConstructor);
            }
            else
            {
                _container.RegisterType<TFrom, TTo>(injectionConstructor);
            }
        }

        public void RegisterType<TFrom, TTo>(string pAliais, bool pUsaParametros, bool pSingleton = false, bool pInjetaContainer = true, params object[] parameterValues) where TTo : TFrom
        {
            var lParameter = new List<InjectionParameter>();
            if (pUsaParametros)
            {
                lParameter.AddRange(from param in parameterValues let type = param.GetType() select new InjectionParameter(type, param));
            }

            if (pInjetaContainer)
            {
                lParameter.Add(new InjectionParameter(this));
            }

            var injectionConstructor =
                new InjectionConstructor(lParameter.ToArray());

            if (pSingleton)
            {
                _container.RegisterType<TFrom, TTo>(pAliais, new PerThreadLifetimeManager(), injectionConstructor);
            }
            else
            {
                _container.RegisterType<TFrom, TTo>(pAliais, injectionConstructor);
            }
        }

        public T Resolve<T>(string key = "")
        {
            if (!String.IsNullOrEmpty(key))
            {
                return _container.Resolve<T>(key);
            }
            else
            {
                return _container.Resolve<T>();
            }
        }

        #endregion

        #region Private Fields

        private readonly IUnityContainer _container;
        private DbTransaction _transaction;

        #endregion
    }
}