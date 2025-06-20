using Final_Project.ViewModels.ContactViewModels;
using FluentValidation;

namespace Final_Project.Validators.ContactValidators
{
    public class ContactCreateVMValidator : AbstractValidator<ContactCreateVM>
    {
       
            public ContactCreateVMValidator()
            {
                RuleFor(x => x.FullName)
                    .NotEmpty().WithMessage("Full name is required.")
                    .MaximumLength(100).WithMessage("Full name must not exceed 100 characters.");

                RuleFor(x => x.Email)
                    .NotEmpty().WithMessage("Email is required.")
                    .EmailAddress().WithMessage("Invalid email format.");

                RuleFor(x => x.Subject)
                    .NotEmpty().WithMessage("Subject is required.")
                    .MaximumLength(100).WithMessage("Subject must not exceed 100 characters.");

                RuleFor(x => x.Message)
                    .NotEmpty().WithMessage("Message is required.")
                    .MaximumLength(1000).WithMessage("Message must not exceed 1000 characters.");
            }
        }

    }
}
