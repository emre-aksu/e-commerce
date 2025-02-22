using AutoMapper;
using ModelLayer.Dtos;
using ModelLayer.Entities;

namespace BusinessLayer.Mapping.Automapper.Profiles
{
    public class CategoryProfile :Profile
    {
        public CategoryProfile()
        {

            CreateMap<CategoryAddDto, Category>();
            CreateMap<CategoryEditDto, Category>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CategoryId));
        }
    }
}
