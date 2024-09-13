using FluentValidation;
using TN.CrudAdvanced.Infrastructure.Command;

namespace TN.CrudAvanced.Api.Integration.Validation
{
    using FluentValidation;

    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Product name must not be empty.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("The product price must be greater than zero.");
        }
    }

}
