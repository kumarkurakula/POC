using FluentValidation;
using OnlineShop.Application.Model;

namespace OnlineShop.Application.Handlers.OrderHandler.Commands
{
    public class CreateOrderCommandHandlerValidator : AbstractValidator<OrderRequest>
    {
        public CreateOrderCommandHandlerValidator()
        {
            RuleFor(command => command.CustomerId)
                .NotEmpty()
                .WithMessage($"{nameof(OrderRequest.CustomerId)} should not be NullOrEmpty");

            RuleFor(command => command.Product)
                .NotEmpty()
                .WithMessage($"{nameof(ProductRequest.ProductName)} should not be NullOrEmpty");
        }
    }
}