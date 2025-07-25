using Microsoft.AspNetCore.Mvc;
using WorkPlace.Domain;
namespace WorkPlace.Infrastructure.Services.Departments;

public interface IDepartmentService
{
    Task<ActionResult<Department>> AddDepartmentAsync(Department department);

    Task<ActionResult<List<Department>>> GetAllDepartmentAsync();
    
    Task<ActionResult<Department>> UpdateDepartmentAsync(int id,Department department);
    
    Task<ActionResult<Department>> DeleteDepartmentAsync(int id);
}