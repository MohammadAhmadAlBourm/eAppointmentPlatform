using Domain.Abstractions;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories;

internal sealed class ServiceRepository(
    AppointmentPlatfromContext _context,
    ILogger<ServiceRepository> _logger) : IServiceRepository
{
    public async Task<Result<bool>> Create(Service service, CancellationToken cancellationToken)
    {
        try
        {
            service.IsDeleted = false;
            service.IsActive = true;
            service.CreatedDate = DateTime.Now;

            await _context.Services.AddAsync(service, cancellationToken);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception occurred {Message}", ex.Message);
            throw;
        }
    }

    public async Task<Result<bool>> Delete(Service service, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _context.Services.FirstOrDefaultAsync(x => x.ServiceId == service.ServiceId, cancellationToken);
            if (entity is null)
            {
                return Result.Failure<bool>(ServiceErrors.ServiceNotFound);
            }

            entity.IsDeleted = service.IsDeleted;
            entity.DeletedBy = service.DeletedBy;
            entity.DeletedDate = DateTime.Now;

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception occurred {Message}", ex.Message);
            throw;
        }
    }

    public async Task<Service?> GetById(long serviceId, CancellationToken cancellationToken)
    {
        try
        {
            return await _context.Services.FirstOrDefaultAsync(x => x.ServiceId == serviceId, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception occurred {Message}", ex.Message);
            throw;
        }
    }

    public async Task<IEnumerable<Service>> GetServices(CancellationToken cancellationToken)
    {
        try
        {
            return await _context.Services
                .Where(x => x.IsDeleted == false)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception occurred {Message}", ex.Message);
            throw;
        }
    }

    public async Task<Result<bool>> Update(Service service, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _context.Services.FirstOrDefaultAsync(x => x.ServiceId == service.ServiceId, cancellationToken);
            if (entity is null)
            {
                return Result.Failure<bool>(ServiceErrors.ServiceNotFound);
            }

            entity.ServiceName = service.ServiceName;
            entity.Description = service.Description;
            entity.Price = service.Price;
            entity.UpdatedBy = service.UpdatedBy;
            entity.UpdatedDate = DateTime.Now;

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception occurred {Message}", ex.Message);
            throw;
        }
    }
}