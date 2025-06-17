using Final_Project.ViewModels.FoodViewModels;
using FluentValidation;

namespace Final_Project.Validators.FoodValidators
{
    public class FoodCreateViewModelValidator : AbstractValidator<FoodCreateVM>
    {
        public FoodCreateViewModelValidator()
       
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.")
                .When(x => !string.IsNullOrEmpty(x.Description));
        }
    }
    }
}
