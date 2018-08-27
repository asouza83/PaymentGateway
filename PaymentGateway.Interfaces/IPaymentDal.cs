namespace PaymentGateway.Interfaces
{
    public interface IPaymentDal
    {
        void SaveTransaction(DataContracts.LocalDb.Transaction pTransaction);
    }
}
