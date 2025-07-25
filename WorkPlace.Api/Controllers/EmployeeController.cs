using Microsoft.AspNetCore.Mvc;
using WorkPlace.Domain;
using WorkPlace.Infrastructure.Services.Employees;

namespace WorkPlace.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        public readonly EmployeeService employeeService;

        public EmployeeController()
        {
            employeeService = new EmployeeService();
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployeeAsync(Employee employee)
        {
            var addedEmployee = await employeeService.AddEmployeeAsync(employee);
            return Ok(addedEmployee);
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployeeAsync()
        {
            var getEmployee = await employeeService.GetAllEmployeesAsync();
            return Ok(getEmployee);
        }

        [HttpPut]
        public async Task<ActionResult<Employee>> PutEmployeeAsync(int id,Employee employee)
        {
            var updatedEmployee = await employeeService.UpdateEmployeeAsync(id, employee);
            return Ok(updatedEmployee);
        }

        [HttpDelete]
        public async Task<ActionResult<Employee>> DeleteEmployeeAsync(int id)
        {
            var deletedEmployee = await employeeService.DeleteEmployeeAsync(id);
            return Ok("The employee has been deleted");
        }

    }
}
