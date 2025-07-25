using Microsoft.AspNetCore.Mvc;
using WorkPlace.Infrastructure.Services.Departments;
using WorkPlace.Domain;

namespace WorkPlace.Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]

    public class DepartmentController : ControllerBase
    {
        public readonly IDepartmentService departmentService;

        public DepartmentController()
        {
            departmentService = new DepartmentService();
        }

        [HttpPost]
        public async Task<ActionResult<Department>> PostDepartmentAsync(Department department)
        {
            var added = await departmentService.AddDepartmentAsync(department);
            return Ok(added);
        }

        [HttpGet]
        public async Task<ActionResult<List<Department>>> GetDepartmentAsync()
        {
            var getting = await departmentService.GetAllDepartmentAsync();
            return Ok(getting);
        }

        [HttpPut]
        public async Task<ActionResult<Department>> PutDepartmentAsync(int id,Department department)
        {
            var putting=await departmentService.UpdateDepartmentAsync( id, department );
            return Ok(putting);
        }

        [HttpDelete]
        public async Task<ActionResult<Department>> DeleteDepartmentAsync(int id)
        {
            var  deleted = await departmentService.DeleteDepartmentAsync( id);
            return Ok("The department has been deleted");
        }

    }
}

