using Final_Project.ViewModels.CommentViewModels;
using Final_Project.ViewModels.FoodViewModels;
using FluentValidation;

namespace Final_Project.Validators.CommentValidators
{
    public class CommentCreateVMValidator : AbstractValidator<CommentCreateVM>
    {
        public CommentCreateVMValidator()
        {
            RuleFor(x => x.Text)
                .NotEmpty().WithMessage("The comment cannot be empty.");

            RuleFor(x => x.BlogId)
                .NotEmpty().WithMessage("Blog Id cannot be empty.");
        }
    }
}
