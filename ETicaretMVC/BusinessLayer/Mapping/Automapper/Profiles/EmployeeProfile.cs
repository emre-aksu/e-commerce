using AutoMapper;
using ModelLayer.Dtos;
using ModelLayer.Entities;

namespace BusinessLayer.Mapping.Automapper.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeAddDto, Employee>();
            CreateMap<EmployeeEditDto, Employee>();
        }
    }
}
