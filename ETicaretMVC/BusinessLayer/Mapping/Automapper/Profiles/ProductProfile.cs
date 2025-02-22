using AutoMapper;
using ModelLayer.Dtos;
using ModelLayer.Entities;
using ModelLayer.JsonResponseObjects;

namespace BusinessLayer.Mapping.Automapper.Profiles
{
    public class ProductProfile :Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductAddDto, Product>();
            CreateMap<Product, ProductJsonResponseObject>();
        }
    }
}
