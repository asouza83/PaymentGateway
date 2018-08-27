using PaymentGateway.Unity;

namespace PaymentGateway.Dal
{
    public class AbstractDal
    {
        #region Protected Constructors

        protected AbstractDal(IContainerIoc container)
        {
            _container = container;
        }

        protected AbstractDal()
        {
        }

        #endregion

        #region Private Fields

        private readonly IContainerIoc _container;

        #endregion
    }
}
