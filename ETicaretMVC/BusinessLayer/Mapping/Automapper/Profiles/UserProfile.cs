using AutoMapper;
using ModelLayer.Dtos;
using ModelLayer.Entities;

namespace BusinessLayer.Mapping.Automapper.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserAddDto, User>();
        }
    }
}
