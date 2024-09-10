namespace Domain.Repositories;

public interface IUserContext
{
    bool IsAuthenticated { get; }
    long UserId { get; }
}