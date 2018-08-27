using PaymentGateway.DataContracts.Dto;

namespace PaymentGateway.Interfaces
{
    public interface IPaymentService
    {
        BaseResponse Payment(PaymentRequest pPaymentRequest);
    }
}
