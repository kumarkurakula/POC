using MediatR;
using OnlineShop.Domain.Enum;

namespace OnlineShop.Application.Model
{
    public class ProductRequest : IRequest<bool>
    {
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public UnitOfMeasurement UnitOfMeasurement { get; set; }
    }
}