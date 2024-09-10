using Braintree;
using Domain.Options;
using Domain.Repositories;
using Microsoft.Extensions.Options;

namespace Infrastructure.Repositories;

internal class BraintreeRepository(IOptions<PaymentGatewayOptions> options) : IBraintreeRepository
{
    public IBraintreeGateway CreateGateway()
    {
        var gateway = new BraintreeGateway()
        {
            Environment = Braintree.Environment.SANDBOX,
            MerchantId = options.Value.MerchantId,
            PublicKey = options.Value.PublicKey,
            PrivateKey = options.Value.PrivateKey
        };

        return gateway;
    }

    public IBraintreeGateway GetGateway()
    {
        return CreateGateway();
    }
}