using OnlineWSModel.Dtos.EmployeeDtos;

namespace OnlineWS.Business.Contracts
{
    public interface IEmployeeManager
    {
        Task<EmployeeGetDto> GetById(int id, params string[] includeList);
        Task<List<EmployeeGetDto>> GetAllEmployees(params string[] includeList);
        Task AddEmployee(EmployeePostDto dto);
        Task UpdateEmployee(EmployeePutDto dto);
        Task DeleteEmployee(int id);
    }
}
