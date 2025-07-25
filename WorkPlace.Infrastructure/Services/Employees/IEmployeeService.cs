using Microsoft.AspNetCore.Mvc;
using WorkPlace.Domain;

namespace WorkPlace.Infrastructure.Services.Employees;

public interface IEmployeeService
{
    Task<Employee> AddEmployeeAsync(Employee employee);

    Task<List<Employee>> GetAllEmployeesAsync();
    
    Task<Employee> UpdateEmployeeAsync(int id, Employee employee);
    
    Task<Employee> DeleteEmployeeAsync(int id);
}