using MediatR;

namespace Application.Appointments.Commands.CreateAppointment;

public sealed record CreateAppointmentCommand(
    long ProviderId,
    long ServiceId,
    long LocationId,
    DateOnly AppointmentDate,
    TimeOnly StartTime,
    TimeOnly EndTime) : IRequest<CreateAppointmentResponse>;