using AutoMapper;
using OnlineShop.Application.Model;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductRequest, Product>().ReverseMap();
            CreateMap<OrderRequest, OrderDetail>().ReverseMap();
            CreateMap<CategoryRequest, Category>().ReverseMap();
        }
    }
}