using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineWS.Business.Contracts;
using OnlineWSModel.Dtos.EmployeeDtos;

namespace OnlineWS.WebAPI.Controllers
{
    [Route("api/employees")]
    [ApiController]
    [Authorize]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeManager _employeeManager;
        public EmployeesController(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            EmployeeGetDto employeeDto=await _employeeManager.GetById(id);
            return Ok(employeeDto);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employeeList=await _employeeManager.GetAllEmployees();
            return Ok(employeeList);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeePostDto dto)
        {
            await _employeeManager.AddEmployee(dto);
            return Ok(dto);
        }
        [HttpPut]
        public async Task<IActionResult> UptadeEmployee([FromBody] EmployeePutDto dto)
        {
            await _employeeManager.UpdateEmployee(dto);
            return Ok(dto);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int id)
        {
            await _employeeManager.DeleteEmployee(id);
            return Ok();
        }


    }
}
