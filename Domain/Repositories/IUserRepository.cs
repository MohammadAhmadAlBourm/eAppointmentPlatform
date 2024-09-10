using Domain.Abstractions;
using Domain.Entities;

namespace Domain.Repositories;

public interface IUserRepository
{
    Task<bool> Create(User user, CancellationToken cancellationToken);
    Task<Result<bool>> Update(User user, CancellationToken cancellationToken);
    Task<Result<bool>> Delete(User user, CancellationToken cancellationToken);
    Task<Result<bool>> Block(User user, CancellationToken cancellationToken);
    Task<User?> GetById(long userId, CancellationToken cancellationToken);
    Task<User?> GetByEmail(string email, CancellationToken cancellationToken);
    Task<IEnumerable<User>> GetUsers(CancellationToken cancellationToken);
    Task<bool> IsExists(string username, CancellationToken cancellationToken);
}