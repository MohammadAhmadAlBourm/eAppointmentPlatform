using Domain.Entities;
using Mapster;

namespace Application.Services.Commands.CreateService;

public static class CreateServiceMapper
{
    public static void Configure()
    {
        TypeAdapterConfig<Service, CreateServiceResponse>.NewConfig();
        TypeAdapterConfig<CreateServiceCommand, Service>.NewConfig();
    }
}