using MediatR;
using OnlineShop.Domain.Entities;
using System.Collections.Generic;

namespace OnlineShop.Application.Model
{
    public class OrderRequest : IRequest<bool>
    {
        public int CustomerId { get; set; }

        public List<Product> Product { get; set; }
    }
}