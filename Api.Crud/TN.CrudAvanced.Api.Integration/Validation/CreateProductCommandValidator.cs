using FluentValidation;
using TN.CrudAdvanced.Infrastructure.Command;

namespace TN.CrudAvanced.Api.Integration.Validation
{
    using FluentValidation;

    public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
    {
        public CreatePersonCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Person name must not be empty.");

            RuleFor(x => x.Idade)
                .GreaterThan(0).WithMessage("The product price must be greater than zero.");
        }
    }

}
