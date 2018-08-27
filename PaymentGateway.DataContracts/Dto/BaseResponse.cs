using System.Runtime.Serialization;

namespace PaymentGateway.DataContracts.Dto
{
    [DataContract]
    public class BaseResponse
    {
        #region Public Constructors

        public BaseResponse()
        {
            Success = true;
        }

        #endregion

        #region Public Properties

        [DataMember]
        public string Menssage { get; set; }

        [DataMember]
        public bool Success { get; set; }

        #endregion
    }
}
