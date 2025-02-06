using AutoMapper;
using MediatR;
using OnlineShop.Application.Model;
using OnlineShop.Domain.Contracts.Persistence;
using OnlineShop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineShop.Application.Handlers.ProductHandler.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<ProductRequest, bool>
    {
        private readonly IApplicationInMemoryDbContext _context;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IApplicationInMemoryDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(ProductRequest request, CancellationToken cancellationToken)
        {
            var products = _mapper.Map<Product>(request);

            var isAdded = await _context.AddProducts(products).ConfigureAwait(false);

            if (isAdded != 1)
            {
                return false;
            }

            return true;
        }
    }
}