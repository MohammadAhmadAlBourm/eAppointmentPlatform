namespace Domain.Exceptions;

public class ValidationResultErrors : Exception
{
    public ValidationResultErrors(string[] errors) : base("Multiple errors occurred. See error details.")
    {
        Errors = errors;
    }

    public string[] Errors { get; set; }
}