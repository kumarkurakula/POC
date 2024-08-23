using MediatR;
using OnlineShop.Domain.Entities;
using OnlineShop.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineShop.Application.Features.ProductsFeatures.Queries
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
    {
        private readonly IApplicationInMemoryDbContext _context;

        public GetAllProductQueryHandler(IApplicationInMemoryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var lstProducts = await _context.GetProducts();

            return lstProducts is null
                ? Enumerable.Empty<Product>()
                : lstProducts;
        }
    }
}
