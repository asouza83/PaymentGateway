using System.Runtime.Serialization;

namespace PaymentGateway.DataContracts.Dto
{
    [DataContract]
    public class PaymentRequest
    {

        [DataMember]
        public int IdStore { get; set; }
        [DataMember]
        public int CreditCardBrand { get; set; }
        [DataMember]
        public string CreditCardNumber { get; set; }
        [DataMember]
        public string ExpMonth { get; set; }
        [DataMember]
        public string ExpYear { get; set; }
        [DataMember]
        public string HolderName { get; set; }
        [DataMember]
        public string SecurityCode { get; set; }
        [DataMember]
        public bool IsTest { get; set; }
    }
}
