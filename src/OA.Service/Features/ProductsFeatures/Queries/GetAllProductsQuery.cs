using MediatR;
using OA.Domain.Entities;
using OA.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace OA.Service.Features.ProductsFeatures.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
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
}