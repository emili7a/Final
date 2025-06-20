using Final_Project.ViewModels.FoodViewModels;
using FluentValidation;

namespace Final_Project.Validators.FoodValidators
{


    public class FoodUpdateViewModelValidator : AbstractValidator<FoodUpdateVM>
    {
        public FoodUpdateViewModelValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0.");

            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("Image URL is required.")
                .Must(url => Uri.IsWellFormedUriString(url, UriKind.Absolute))
                .WithMessage("Invalid URL format.");

            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("Please select a category.");

            RuleFor(x => x.SelectedIngredientIds)
                .Must(list => list != null && list.Any())
                .WithMessage("At least one ingredient must be selected.");
        }
    }
}
