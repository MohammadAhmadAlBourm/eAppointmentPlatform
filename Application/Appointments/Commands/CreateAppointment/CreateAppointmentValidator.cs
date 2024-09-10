using FluentValidation;

namespace Application.Appointments.Commands.CreateAppointment;

internal sealed class CreateAppointmentValidator : AbstractValidator<CreateAppointmentCommand>
{
    public CreateAppointmentValidator()
    {

    }
}