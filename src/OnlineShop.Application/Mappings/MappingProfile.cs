using AutoMapper;
using OnlineShop.Application.Features.OrderFeatures.Commands;
using OnlineShop.Application.Features.ProductsFeatures.Commands;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddProductCommand, Product>().ReverseMap();
            CreateMap<CreateOrderCommand, OrderDetail>().ReverseMap();
        }
    }
}