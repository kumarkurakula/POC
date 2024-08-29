using MediatR;
using OnlineShop.Application.Contracts.Persistence;
using OnlineShop.Application.Features.ProductsFeatures.Queries;
using OnlineShop.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace OnlineShop.Application.Features.CategoryFeature.Queries
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, IEnumerable<Category>>
    {
        private readonly IApplicationInMemoryDbContext _context;

        public GetAllCategoryQueryHandler(IApplicationInMemoryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var lstCategory = await _context.GetCateroy().ConfigureAwait(false);

            return lstCategory.Any()
                ? lstCategory
                : Enumerable.Empty<Category>();
        }

    }
}