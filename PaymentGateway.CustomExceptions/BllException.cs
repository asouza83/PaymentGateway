using System;

namespace PaymentGateway.CustomExceptions
{
    public class BllException : Exception
    {
        #region Public Constructors

        public BllException(string message)
            : base(message)
        {
        }

        #endregion
    }
}
