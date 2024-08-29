using MediatR;
using OnlineShop.Domain.Entities;
using System.Collections.Generic;

namespace OnlineShop.Application.Features.CategoryFeature.Queries
{
    public class GetAllCategoryQuery : IRequest<IEnumerable<Category>>
    {
    }
}