using PaymentGateway.DataContracts.LocalDb;

namespace PaymentGateway.Interfaces
{
    public interface IStoreDal
    {
        Store GetStoreById(GetStore pGetStore);
    }
}
