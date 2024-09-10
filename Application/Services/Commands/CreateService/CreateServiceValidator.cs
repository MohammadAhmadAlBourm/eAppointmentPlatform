using FluentValidation;

namespace Application.Services.Commands.CreateService;

internal sealed class CreateServiceValidator : AbstractValidator<CreateServiceCommand>
{
    public CreateServiceValidator()
    {
        RuleFor(x => x.ServiceName)
            .NotEmpty().WithMessage("Service Name is Required")
            .MaximumLength(50).WithMessage("Service Name should not exceed the 50 characters");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is Required")
            .MaximumLength(500).WithMessage("Description should not exceed the 500 characters");

        RuleFor(x => x.Price)
            .NotEmpty().WithMessage("Price is Required")
            .GreaterThan(0).WithMessage("Price should be greater than 0");
    }
}