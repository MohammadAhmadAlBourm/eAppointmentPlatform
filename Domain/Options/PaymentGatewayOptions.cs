using System.ComponentModel.DataAnnotations;

namespace Domain.Options;

public class PaymentGatewayOptions
{
    [Required]
    public string Environment { get; init; } = string.Empty;

    [Required]
    public string MerchantId { get; init; } = string.Empty;

    [Required]
    public string PublicKey { get; init; } = string.Empty;

    [Required]
    public string PrivateKey { get; init; } = string.Empty;
}