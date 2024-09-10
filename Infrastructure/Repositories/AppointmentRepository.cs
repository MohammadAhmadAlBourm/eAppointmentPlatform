using Domain.Abstractions;
using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Repositories;

internal sealed class AppointmentRepository : IAppointmentRepository
{
    public Task<Result<bool>> Create(Appointment appointment, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Result<bool>> Delete(Appointment appointment, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Appointment>> GetAppointments(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Appointment?> GetById(long appointmentId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Appointment>> GetByUserId(long userId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Result<bool>> Update(Appointment appointment, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}