using FluentValidation;
using GymFlow.CustomerService.Domain.Entities;

namespace GymFlow.CustomerService.Application.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Full name is required.").MaximumLength(255);
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone is required.").MaximumLength(20).Matches(@"^\+?[0-9]{10,15}$").WithMessage("Invalid phone number format.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.").EmailAddress().WithMessage("Invalid email format.").MaximumLength(255);
            RuleFor(x => x.Address).MaximumLength(500);
        }
    }
}
