using Application.Abstractions;

namespace Application.Authentication.Queries.GetProfile;

public sealed record GetProfileQuery() : IQuery<GetProfileResponse>;