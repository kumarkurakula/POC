using FluentValidation;
using OnlineShop.Application.Model;

namespace OnlineShop.Application.Handlers.CategoryHandler.Commands
{
    public class CreateCategoryCommandHandlerValidator : AbstractValidator<CategoryRequest>
    {
        public CreateCategoryCommandHandlerValidator()
        {
            RuleFor(command => command.CategoryId)
                .NotEmpty()
                .WithMessage($"{nameof(CategoryRequest.CategoryId)} should not be NullOrEmpty");
            RuleFor(command => command.CategoryName)
                .NotEmpty()
                .WithMessage($"{nameof(CategoryRequest.CategoryName)} should not be NullOrEmpty");
        }
    }
}