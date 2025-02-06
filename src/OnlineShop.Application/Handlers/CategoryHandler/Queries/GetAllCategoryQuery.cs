using MediatR;
using OnlineShop.Domain.Entities;
using System.Collections.Generic;

namespace OnlineShop.Application.Handlers.CategoryHandler.Queries
{
    public class GetAllCategoryQuery : IRequest<IEnumerable<Category>>
    {
    }
}