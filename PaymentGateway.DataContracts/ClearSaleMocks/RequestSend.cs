using System.Collections.Generic;

namespace PaymentGateway.DataContracts.ClearSaleMocks
{
    public class RequestSend
    {
        public string ApiKey { get; set; }
        public string LoginToken { get; set; }
        public IList<Order> Orders { get; set; }
        public string AnalysisLocation { get; set; }
    }
}
