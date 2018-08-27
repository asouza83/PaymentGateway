using System;

namespace StonePaymentGateway.ResourceClients.Interfaces {

    public interface IBaseResource {

        /// <summary>
        /// Chave da loja. Utilizada para identificar uma loja no gateway.
        /// </summary>
        Guid MerchantKey { get; set; }

        /// <summary>
        /// Nome do recurso que será acessado.
        /// </summary>
        string ResourceName { get; }
    }
}
