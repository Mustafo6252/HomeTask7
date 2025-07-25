using Microsoft.AspNetCore.Mvc;
using WorkPlace.Domain;
namespace WorkPlace.Infrastructure.Services.Departments;

public interface IDepartmentService
{
    Task<Department> AddDepartmentAsync(Department department);

    Task<List<Department>> GetAllDepartmentAsync();
    
    Task<Department> UpdateDepartmentAsync(int id,Department department);
    
    Task<Department> DeleteDepartmentAsync(int id);
}