using FluentValidation;
using PersonManager.Api.Commands;

namespace PersonManager.Api.CommandValidators
{
    public class AddPersonCommandValidator : AbstractValidator<AddPersonCommand>
    {
        public AddPersonCommandValidator()
        {
            RuleFor(r => r.Name).NotEmpty();
            RuleFor(r => r.GroupId).GreaterThan(0);
        }
    }
}
