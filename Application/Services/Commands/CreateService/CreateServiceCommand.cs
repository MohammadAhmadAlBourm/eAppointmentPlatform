using Application.Abstractions;

namespace Application.Services.Commands.CreateService;

public sealed record CreateServiceCommand(
    string ServiceName,
    string Description,
    decimal Price) : ICommand<CreateServiceResponse>;