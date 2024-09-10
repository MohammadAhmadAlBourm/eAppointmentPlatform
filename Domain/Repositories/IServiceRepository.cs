using Domain.Abstractions;
using Domain.Entities;

namespace Domain.Repositories;

public interface IServiceRepository
{
    Task<Result<bool>> Create(Service service, CancellationToken cancellationToken);
    Task<Result<bool>> Update(Service service, CancellationToken cancellationToken);
    Task<Result<bool>> Delete(Service service, CancellationToken cancellationToken);
    Task<Service?> GetById(long serviceId, CancellationToken cancellationToken);
    Task<IEnumerable<Service>> GetServices(CancellationToken cancellationToken);
}