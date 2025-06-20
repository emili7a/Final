using Final_Project.ViewModels.CartItemViewModels;
using FluentValidation;

namespace Final_Project.Validators.CartItemValidators
{
    public class CartItemCreateViewModelValidator : AbstractValidator<CartItemCreateVM>
    {
        public CartItemCreateViewModelValidator()
        {
            RuleFor(x => x.FoodId)
                .GreaterThan(0).WithMessage("Food selection is required.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be at least 1.");
        }
    }

}
