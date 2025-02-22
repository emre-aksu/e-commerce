using AutoMapper;
using OnlineWSModel.Dtos.EmployeeDtos;
using OnlineWSModel.Entities;

namespace OnlineWS.Business.Mapping.Automapper.Profiles
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeGetDto>();
            CreateMap<EmployeePostDto, Employee>();
            CreateMap<EmployeePutDto, Employee>();
        }
    }
}
