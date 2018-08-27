namespace PaymentGateway.DataContracts.LocalDb
{
    public class RelStoreAcquirer
    {
        public int IdStore { get; set; }
        public Store Store { get; set; }
        public int IdAcquirer { get; set; }
        public Acquirer Acquirer { get; set; }
    }
}
