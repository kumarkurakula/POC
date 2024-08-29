using MediatR;

namespace OnlineShop.Application.Features.CategoryFeature.Commands
{
    public class CreateCategoryCommand : IRequest<bool>
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}