using AutoMapper;
using MediatR;
using OnlineShop.Domain.Entities;
using OnlineShop.Infrastructure.Persistence;
using System.Threading.Tasks;
using System.Threading;

namespace OnlineShop.Application.Features.OrderFeatures.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, bool>
    {
        private readonly IApplicationInMemoryDbContext _context;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IApplicationInMemoryDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var orders = _mapper.Map<OrderDetail>(request);

            var isAdded = await _context.CreateOrders(orders);

            if (isAdded != 1)
            {
                return false;
            }

            return true;
        }
    }
}