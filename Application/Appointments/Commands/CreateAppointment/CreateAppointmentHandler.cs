using Domain.Entities;
using Domain.Repositories;
using MapsterMapper;
using MediatR;

namespace Application.Appointments.Commands.CreateAppointment;

internal sealed class CreateAppointmentHandler(IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<CreateAppointmentCommand, CreateAppointmentResponse>
{
    public async Task<CreateAppointmentResponse> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
    {
        var appointment = _mapper.Map<Appointment>(request);

        await _unitOfWork.AppointmentRepository.Create(appointment, cancellationToken);
        await _unitOfWork.CompleteAsync(cancellationToken);

        return _mapper.Map<CreateAppointmentResponse>(appointment);
    }
}