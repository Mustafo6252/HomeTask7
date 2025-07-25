using Microsoft.AspNetCore.Mvc;
using WorkPlace.Domain;

namespace WorkPlace.Infrastructure.Services.Employees;

public interface IEmployeeService
{
    Task<ActionResult<Employee>> AddEmployeeAsync(Employee employee);

    Task<ActionResult<List<Employee>>> GetAllEmployeesAsync();
    
    Task<ActionResult<Employee>> UpdateEmployeeAsync(int id, Employee employee);
    
    Task<ActionResult<Employee>> DeleteEmployeeAsync(int id);
}