using Domain.Abstractions;
using Domain.Entities;

namespace Domain.Repositories;

public interface IAppointmentRepository
{
    Task<Result<bool>> Create(Appointment appointment, CancellationToken cancellationToken);
    Task<Result<bool>> Update(Appointment appointment, CancellationToken cancellationToken);
    Task<Result<bool>> Delete(Appointment appointment, CancellationToken cancellationToken);
    Task<Appointment?> GetById(long appointmentId, CancellationToken cancellationToken);
    Task<IEnumerable<Appointment>> GetAppointments(CancellationToken cancellationToken);
    Task<IEnumerable<Appointment>> GetByUserId(long userId, CancellationToken cancellationToken);
}