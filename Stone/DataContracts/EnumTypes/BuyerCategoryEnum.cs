using System.Runtime.Serialization;

namespace StonePaymentGateway.DataContracts.EnumTypes {

    /// <summary>
    /// Categoria do comprador
    /// </summary>
    [DataContract]
    public enum BuyerCategoryEnum {

        /// <summary>
        /// Normal
        /// </summary>
        [DataMember]
        Normal = 1,

        /// <summary>
        /// Plus
        /// </summary>
        [DataMember]
        Plus = 1,
    }
}