using MediatR;

namespace OnlineShop.Application.Model
{
    public class CategoryRequest : IRequest<bool>
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}