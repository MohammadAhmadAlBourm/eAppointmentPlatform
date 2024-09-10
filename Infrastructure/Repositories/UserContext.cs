﻿using Domain.Repositories;
using Infrastructure.Extensions;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Repositories;

internal sealed class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
{
    public bool IsAuthenticated => httpContextAccessor
        .HttpContext?
        .User
        .Identity?
        .IsAuthenticated ?? throw new ApplicationException("User context is unavailable");

    public long UserId => httpContextAccessor
        .HttpContext?
        .User
        .GetUserId() ?? throw new ApplicationException("User context is unavailable");
}