using Domain.Abstractions;

namespace Domain.Exceptions;

public static class ServiceErrors
{
    public static Error ServiceNotFound = new("Service.Id", "Service with the provided id was not found");
}