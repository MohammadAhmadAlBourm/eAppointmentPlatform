using Domain.Abstractions;

namespace Domain.Exceptions;

public static class UserErrors
{
    public static Error UserNotFound = new("User.Id", "User with the provided id was not found");
    public static Error UserEmailNotFound = new("User.Email", "User with the provided email was not found");
    public static Error UserPasswordNotMatching = new("User.Password", "User Password Not Matching");
    public static Error UserEmailNotValid = new("User.Email", "User email is not valid");
    public static Error UserNameTooShort = new("User.Name", "User name is too short");
    public static Error UserPasswordTooWeak = new("User.Password", "User password is too weak");
    public static Error UserAlreadyExists = new("User.Exists", "User with the provided details already exists");
    public static Error UserNotAuthorized = new("User.Authorization", "User is not authorized to perform this action");
    public static Error UserAccountLocked = new("User.Account.Locked", "User account is locked");
    public static Error UserTokenExpired = new("User.Token.Expired", "User authentication token has expired");
    public static Error UserProfileIncomplete = new("User.Profile.Incomplete", "User profile is incomplete");
    public static Error UserEmailAlreadyExist = new("User.Email", "User Email already Exist");
    public static Error NotSavedSuccessfully = new("User", "An Issue occurred while creating your user");
}