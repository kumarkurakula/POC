using MediatR;
using OA.Domain.Entities;
using OA.Domain.Enum;
using OA.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace OA.Service.Features.ProductsFeatures.Commands
{
    public class AddProductCommand : IRequest<bool>
    {
        public int CategoryId { get; init; }
        public UnitOfMeasurement UnitOfMeasurement { get; init; }
        public short QuantityInPackage { get; init; }
        public string ProductName { get; init; }
    }

    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, bool>
    {
        private readonly IApplicationInMemoryDbContext _context;

        public AddProductCommandHandler(IApplicationInMemoryDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var products = new Product
            {
                CategoryId = request.CategoryId,
                ProductName = request.ProductName,
                UnitOfMeasurement = request.UnitOfMeasurement,
                UnitPrice = request.QuantityInPackage,
            };
            var isAdded = await _context.AddProducts(products);

            if (isAdded != 1)
            {
                return false;
            }

            return true;
        }
    }
}