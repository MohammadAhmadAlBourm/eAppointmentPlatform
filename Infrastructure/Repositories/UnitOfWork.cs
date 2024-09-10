using Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories;

internal class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly AppointmentPlatfromContext _context;
    private readonly ILogger _logger;

    public UnitOfWork(
        AppointmentPlatfromContext context,
        ILoggerFactory logger,
        IAppointmentRepository appointmentRepository,
        IPaymentRepository paymentRepository,
        IServiceRepository serviceRepository,
        IUserRepository userRepository)
    {

        _context = context;
        _logger = logger.CreateLogger("Logs");
        AppointmentRepository = appointmentRepository;
        PaymentRepository = paymentRepository;
        ServiceRepository = serviceRepository;
        UserRepository = userRepository;
    }

    public IAppointmentRepository AppointmentRepository { get; private set; }

    public IPaymentRepository PaymentRepository { get; private set; }

    public IServiceRepository ServiceRepository { get; private set; }

    public IUserRepository UserRepository { get; private set; }
    public async Task CompleteAsync(CancellationToken cancellationToken)
    {
        try
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception occurred {Message}", ex.Message);
            throw;
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}