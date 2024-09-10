﻿using Domain.Entities;
using Mapster;

namespace Application.Authentication.Queries.GetProfile;

internal static class GetProfileMapper
{
    public static void Configure()
    {
        TypeAdapterConfig<User, GetProfileResponse>.NewConfig();
    }
}