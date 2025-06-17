using Final_Project.ViewModels.CommentViewModels;
using FluentValidation;

namespace Final_Project.Validators.CommentValidators
{
    public class CommentUpdateVMValidator : AbstractValidator<CommentUpdateVM>
    {
        public CommentUpdateVMValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id cannot be empty.");

            RuleFor(x => x.Text)
                .NotEmpty().WithMessage("The comment cannot be empty.");

            RuleFor(x => x.BlogId)
                .NotEmpty().WithMessage("Blog Id cannot be empty.");
        }
    }
}
