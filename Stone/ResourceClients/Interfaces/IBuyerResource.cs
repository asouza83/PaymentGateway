using System;
using StonePaymentGateway.DataContracts;
using StonePaymentGateway.Utility;

namespace StonePaymentGateway.ResourceClients.Interfaces {
    public interface IBuyerResource {
        HttpResponse<GetBuyerData> GetBuyer(Guid buyerKey);

        HttpResponse<CreateBuyerResponse> CreateBuyer(CreateBuyerRequest createBuyerRequest);
    }
}