﻿using System;
using System.Runtime.Serialization;

namespace StonePaymentGateway.DataContracts {

    [DataContract(Namespace = "")]
    public class UpdateInstantBuyDataRequest {

        /// <summary>
        /// Chave do Comprador
        /// </summary>
        [DataMember]
        public Guid BuyerKey { get; set; }
    }
}
