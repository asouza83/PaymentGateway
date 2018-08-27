using System.Collections.Generic;

namespace PaymentGateway.DataContracts.LocalDb
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool FlAntiFraud { get; set; }
        public ICollection<RelStoreAcquirer> RelStoreAcquirer { get; set; }
    }
}
