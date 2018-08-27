using PaymentGateway.DataContracts.LocalDb;
using System.Runtime.Serialization;

namespace PaymentGateway.DataContracts.Dto
{
    [DataContract]
    public class PaymentResponse : BaseResponse
    {
        [DataMember]
        public Transaction Transaction { get; set; }
    }
}
