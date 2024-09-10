namespace Domain.Repositories;

public interface IUnitOfWork
{
    IAppointmentRepository AppointmentRepository { get; }
    IPaymentRepository PaymentRepository { get; }
    IServiceRepository ServiceRepository { get; }
    IUserRepository UserRepository { get; }
    Task CompleteAsync(CancellationToken cancellationToken);
}