using ModelLayer.Dtos;
using ModelLayer.Entities;

namespace BusinessLayer.Abstract
{
    public interface IEmployeeManager
    {
        Task<Employee> LogIn(LogInDto dto);
    }
}
