using PaymentGateway.CustomExceptions;
using PaymentGateway.DataContracts.Dto;
using PaymentGateway.Unity;
using System;

namespace PaymentGateway.Services
{
    public abstract class AbstractService
    {
        #region Public Constructors
        protected AbstractService()
        {

        }

        protected AbstractService(IContainerIoc pContainer)
        {
            Container = pContainer;
        }

        #endregion

        #region Public Fields

        public bool LazyInit;

        #endregion

        #region Public Methods

        protected void HandleException(Exception ex, BaseResponse response)
        {
            if (ex is BllException)
            {
                response.Menssage = ex.Message;
            }
            else { response.Menssage = "There was an unexpected error!"; }

            response.Success = false;
        }

        //protected void ValidaRequest(BaseRequest request)
        //{
        //    if (request == null) { throw new NullReferenceException("Request está vazio!"); }
        //}

        #endregion

        #region Protected Fields

        protected readonly IContainerIoc Container;

        #endregion
    }
}
