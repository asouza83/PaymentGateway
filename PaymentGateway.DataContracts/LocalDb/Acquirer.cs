using System.Collections.Generic;

namespace PaymentGateway.DataContracts.LocalDb
{
    public class Acquirer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MerchanteKey { get; set; }
        public ICollection<RelStoreAcquirer> RelStoreAcquirer { get; set; }
    }
}
