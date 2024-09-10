using Braintree;

namespace Domain.Repositories;

public interface IBraintreeRepository
{
    IBraintreeGateway CreateGateway();
    IBraintreeGateway GetGateway();
}