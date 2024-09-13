using FluentValidation;
using TN.CrudAdvanced.Infrastructure.Command;

namespace TN.CrudAvanced.Api.Integration.Validation
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("The product price must be greater than zero.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("The product name must not be empty.");
        }
    }
}

