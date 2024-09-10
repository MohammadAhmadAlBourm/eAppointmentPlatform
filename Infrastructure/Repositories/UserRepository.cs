using Domain.Abstractions;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories;

internal class UserRepository(
    AppointmentPlatfromContext _context,
    ILogger<UserRepository> _logger) : IUserRepository
{
    public async Task<Result<bool>> Block(User user, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _context.Users.FirstOrDefaultAsync(x => x.UserId == user.UserId, cancellationToken);
            if (entity is null)
            {
                return Result.Failure<bool>(UserErrors.UserNotFound);
            }

            entity.IsBlocked = user.IsBlocked;
            entity.BlockedBy = user.BlockedBy;
            entity.BlockedDate = DateTime.Now;

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception occurred {Message}", ex.Message);
            throw;
        }
    }

    public async Task<bool> Create(User user, CancellationToken cancellationToken)
    {
        try
        {
            user.IsActive = true;
            user.IsDeleted = false;
            user.IsBlocked = false;

            user.CreatedDate = DateTime.Now;

            await _context.Users.AddAsync(user, cancellationToken);

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception occurred {Message}", ex.Message);
            throw;
        }
    }

    public async Task<Result<bool>> Delete(User user, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _context.Users.FirstOrDefaultAsync(x => x.UserId == user.UserId, cancellationToken);
            if (entity is null)
            {
                return Result.Failure<bool>(UserErrors.UserNotFound);
            }

            entity.IsDeleted = user.IsDeleted;
            entity.DeletedBy = user.DeletedBy;
            entity.DeletedDate = DateTime.Now;

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception occurred {Message}", ex.Message);
            throw;
        }
    }

    public async Task<User?> GetByEmail(string email, CancellationToken cancellationToken)
    {
        try
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception occurred {Message}", ex.Message);
            throw;
        }
    }

    public async Task<User?> GetById(long userId, CancellationToken cancellationToken)
    {
        try
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.UserId == userId, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception occurred {Message}", ex.Message);
            throw;
        }
    }

    public async Task<IEnumerable<User>> GetUsers(CancellationToken cancellationToken)
    {
        try
        {
            return await _context.Users
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

    public async Task<Result<bool>> Update(User user, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _context.Users.FirstOrDefaultAsync(x => x.UserId == user.UserId, cancellationToken);
            if (entity is null)
            {
                return Result.Failure<bool>(UserErrors.UserNotFound);
            }

            entity.FirstName = user.FirstName;
            entity.LastName = user.LastName;
            entity.Gender = user.Gender;
            entity.DateOfBirth = user.DateOfBirth;
            entity.UpdatedBy = user.UpdatedBy;
            entity.UpdatedDate = DateTime.Now;


            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception occurred {Message}", ex.Message);
            throw;
        }
    }

    public async Task<bool> IsExists(string username, CancellationToken cancellationToken)
    {
        try
        {
            return await _context.Users.AnyAsync(x => x.Username == username, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception occurred {Message}", ex.Message);
            throw;
        }
    }
}