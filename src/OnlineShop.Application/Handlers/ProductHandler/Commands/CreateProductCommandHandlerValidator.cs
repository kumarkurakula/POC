using FluentValidation;
using OnlineShop.Application.Model;

namespace OnlineShop.Application.Handlers.ProductHandler.Commands
{
    public class CreateProductCommandHandlerValidator : AbstractValidator<ProductRequest>
    {
        public CreateProductCommandHandlerValidator()
        {
            RuleFor(command => command.CategoryId)
                .GreaterThan(0)
                .WithMessage($"{nameof(ProductRequest.CategoryId)} should not be NullOrEmpty");

            RuleFor(command => command.ProductName)
                .NotEmpty()
                .WithMessage($"{nameof(ProductRequest.ProductName)} should not be NullOrEmpty");

            RuleFor(command => command.UnitPrice)
                .NotEmpty()
                .WithMessage($"{nameof(ProductRequest.UnitPrice)} should not be NullOrEmpty");

            RuleFor(command => command.UnitOfMeasurement)
                .NotEmpty()
                .WithMessage($"{nameof(ProductRequest.UnitOfMeasurement)} should not be NullOrEmpty");
        }
    }
}