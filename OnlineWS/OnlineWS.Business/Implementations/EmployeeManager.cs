using AutoMapper;
using OnlineWS.Business.Contracts;
using OnlineWS.DateAccess.Contracts.Repositories;
using OnlineWSModel.Dtos.EmployeeDtos;
using OnlineWSModel.Entities;

namespace OnlineWS.Business.Implementations
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public EmployeeManager(IEmployeeRepository employeeRepositor, IMapper mapper)
        {
            _employeeRepository = employeeRepositor;
            _mapper = mapper;
        }
        public async Task AddEmployee(EmployeePostDto dto)
        {
            var entity = _mapper.Map<Employee>(dto);
            await _employeeRepository.InsertAsync(entity);
        }

        public async Task DeleteEmployee(int id)
        {
            await _employeeRepository.DeleteAsync(id);
        }

        public async Task<List<EmployeeGetDto>> GetAllEmployees(params string[] includeList)
        {
            List<Employee> employees=await _employeeRepository.GetAllAsycn(includeList);
            List<EmployeeGetDto> list=_mapper.Map<List<EmployeeGetDto>>(employees);
            return list;    
        }

        public async Task<EmployeeGetDto> GetById(int id, params string[] includeList)
        {
            Employee employee = await _employeeRepository.GetByIdAsync(id, includeList);
            EmployeeGetDto dto=_mapper.Map<EmployeeGetDto>(employee);
            return dto;
        }

        public async Task UpdateEmployee(EmployeePutDto dto)
        {
            var entity=_mapper.Map<Employee>(dto);
            await _employeeRepository.UpdateAsync(entity);
        }
      
    }
}
