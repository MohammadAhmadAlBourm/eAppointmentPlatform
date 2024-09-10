namespace Application.Authentication.Commands.Register;

public sealed class RegisterResponse
{
    public long UserId { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Username { get; set; } = string.Empty;

    public string Gender { get; set; } = string.Empty;

    public DateOnly DateOfBirth { get; set; }

    public int Age { get; set; }

    public string Role { get; set; } = string.Empty;

    public bool IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }
}