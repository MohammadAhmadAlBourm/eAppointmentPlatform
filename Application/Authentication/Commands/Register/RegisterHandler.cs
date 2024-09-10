using Application.Abstractions;
using Application.Common;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Options;
using Domain.Repositories;
using MapsterMapper;
using Microsoft.Extensions.Options;

namespace Application.Authentication.Commands.Register;

internal sealed class RegisterHandler(
    IUnitOfWork _unitOfWork,
    IMapper _mapper,
    IOptions<PasswordHasherOptions> _options)
    : ICommandHandler<RegisterCommand, RegisterResponse>
{
    public async Task<Result<RegisterResponse>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(request);

        user.Username = user.Email.Split('@')[0];
        user.Salt = PasswordHasher.GenerateSalt();
        user.Password = PasswordHasher.ComputeHash(user.Password, user.Salt, _options.Value.Pepper, _options.Value.Iteration);
        user.Role = Role.Customer;


        var isExist = await _unitOfWork.UserRepository.IsExists(user.Username, cancellationToken);

        if (isExist)
        {
            return Result.Failure<RegisterResponse>(UserErrors.UserEmailAlreadyExist);
        }

        await _unitOfWork.UserRepository.Create(user, cancellationToken);
        await _unitOfWork.CompleteAsync(cancellationToken);

        return _mapper.Map<RegisterResponse>(user);
    }
}