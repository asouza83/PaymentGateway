﻿using System.Runtime.Serialization;

namespace StonePaymentGateway.DataContracts {

    [DataContract(Namespace = "")]
    public class DeleteInstantBuyDataResponse : BaseResponse {

        /// <summary>
        /// Indicador de sucesso
        /// </summary>
        [DataMember]
        public bool Success { get; set; }
    }
}
