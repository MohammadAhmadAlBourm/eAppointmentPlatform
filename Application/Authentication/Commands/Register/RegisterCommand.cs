using Application.Abstractions;

namespace Application.Authentication.Commands.Register;

public sealed record RegisterCommand(
    string FirstName,
    string LastName,
    string Gender,
    DateOnly DateOfBirth,
    string Email,
    string Password,
    string ConfirmationPassword) : ICommand<RegisterResponse>;