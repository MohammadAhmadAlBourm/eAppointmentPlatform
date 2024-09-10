using Application.Abstractions;
using Application.Common;
using Domain.Abstractions;
using Domain.Exceptions;
using Domain.Options;
using Domain.Repositories;
using Microsoft.Extensions.Options;

namespace Application.Authentication.Commands.Login;

internal sealed class LoginHandler(
    IUnitOfWork _unitOfWork,
    IAuthenticationRepository _authenticationRepository,
    IOptions<PasswordHasherOptions> _options)
    : ICommandHandler<LoginCommand, LoginResponse>
{
    public async Task<Result<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.UserRepository.GetByEmail(request.Email, cancellationToken);

        if (user is null)
        {
            return Result.Failure<LoginResponse>(UserErrors.UserEmailNotFound);
        }

        string password = PasswordHasher.ComputeHash(request.Password, user.Salt, _options.Value.Pepper, _options.Value.Iteration);

        if (password != user.Password)
        {
            return Result.Failure<LoginResponse>(UserErrors.UserPasswordNotMatching);
        }

        var token = _authenticationRepository.GenerateToken(user);

        return new LoginResponse
        {
            Token = token
        };
    }
}