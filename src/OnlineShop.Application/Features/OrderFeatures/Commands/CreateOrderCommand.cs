using MediatR;
using OnlineShop.Domain;
using OnlineShop.Domain.Entities;
using System.Collections.Generic;

namespace OnlineShop.Application.Features.OrderFeatures.Commands
{
    public class CreateOrderCommand : IRequest<bool>
    {
        public int CustomerId { get; set; }
        public int OrderId { get; set; }

        public List<Product> Product { get; set; }
    }
}