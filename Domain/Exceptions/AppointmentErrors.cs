using Domain.Abstractions;

namespace Domain.Exceptions;

public class AppointmentErrors
{
    public static Error AppointmentNotFound = new("Appointment.Id", "Appointment with the provided id was not found");

}