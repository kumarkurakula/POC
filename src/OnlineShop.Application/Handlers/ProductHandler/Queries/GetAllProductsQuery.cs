using MediatR;
using OnlineShop.Domain.Entities;
using System.Collections.Generic;

namespace OnlineShop.Application.Handlers.ProductHandler.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}