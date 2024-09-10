﻿using Domain.Entities;
using Mapster;

namespace Application.Authentication.Commands.Register;

internal static class RegisterMapper
{
    public static void Configure()
    {
        TypeAdapterConfig<RegisterCommand, User>.NewConfig();
        TypeAdapterConfig<User, RegisterResponse>.NewConfig();
    }
}