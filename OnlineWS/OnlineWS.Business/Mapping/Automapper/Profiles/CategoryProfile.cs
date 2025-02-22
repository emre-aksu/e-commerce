using AutoMapper;
using OnlineWSModel.Dtos.CategoryDtos;
using OnlineWSModel.Entities;

namespace OnlineWS.Business.Mapping.Automapper.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryGetDto>()
                .ForMember(dest => dest.ProductCount, opt => opt.MapFrom(src => src.Products != null ? src.Products.Count : 0));

            CreateMap<CategoryPostDto, Category>();
            CreateMap<CategoryPutDto, Category>();
        }
    }
}
