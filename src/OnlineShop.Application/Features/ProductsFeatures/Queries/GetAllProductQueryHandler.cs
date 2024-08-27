using MediatR;
using OnlineShop.Application.Contracts.Persistence;
using OnlineShop.Domain.Entities;
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
            var lstProducts = await _context.GetProducts().ConfigureAwait(false);

            return lstProducts.Any()
                ? lstProducts
                : Enumerable.Empty<Product>();
        }
    }
}