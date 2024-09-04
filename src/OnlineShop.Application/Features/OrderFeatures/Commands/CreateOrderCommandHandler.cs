using AutoMapper;
using MediatR;
using OnlineShop.Application.Model;
using OnlineShop.Domain.Contracts.Persistence;
using OnlineShop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineShop.Application.Features.OrderFeatures.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<OrderRequest, bool>
    {
        private readonly IApplicationInMemoryDbContext _context;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IApplicationInMemoryDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(OrderRequest request, CancellationToken cancellationToken)
        {
            var orders = _mapper.Map<OrderDetail>(request);

            var isAdded = await _context.CreateOrders(orders).ConfigureAwait(false);

            if (isAdded >= 1)
            {
                return true;
            }

            return false;
        }
    }
}