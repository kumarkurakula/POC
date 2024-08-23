using MediatR;
using OnlineShop.Domain.Enum;

namespace OnlineShop.Application.Features.ProductsFeatures.Commands
{
    public class AddProductCommand : IRequest<bool>
    {
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public UnitOfMeasurement UnitOfMeasurement { get; set; }
    }
}