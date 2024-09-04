using AutoMapper;
using MediatR;
using OnlineShop.Application.Model;
using OnlineShop.Domain.Contracts.Persistence;
using OnlineShop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineShop.Application.Features.CategoryFeature.Commands
{
    public class CreateCategoryCommandHandler : IRequestHandler<CategoryRequest, bool>
    {
        private readonly IApplicationInMemoryDbContext _context;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(IApplicationInMemoryDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CategoryRequest request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request);
            var response = await _context.CreateCategory(category);

            if (response >= 1)
            {
                return true;
            }

            return false;
        }
    }
}