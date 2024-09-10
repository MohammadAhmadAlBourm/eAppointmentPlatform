using Application.Abstractions;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Repositories;
using MapsterMapper;

namespace Application.Services.Commands.CreateService;

internal sealed class CreateServiceHandler(
    IUnitOfWork _unitOfWork,
    IUserContext _userContext,
    IMapper mapper) : ICommandHandler<CreateServiceCommand, CreateServiceResponse>
{
    public async Task<Result<CreateServiceResponse>> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
    {
        var service = mapper.Map<Service>(request);
        service.CreatedBy = _userContext.UserId;

        var response = await _unitOfWork.ServiceRepository.Create(service, cancellationToken);

        if (response.IsFailure)
        {
            return Result.Failure<CreateServiceResponse>(response.Error);
        }

        await _unitOfWork.CompleteAsync(cancellationToken);

        return mapper.Map<CreateServiceResponse>(service);
    }
}