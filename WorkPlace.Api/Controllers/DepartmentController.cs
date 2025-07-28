using Dapper;
using Microsoft.AspNetCore.Mvc;
using WorkPlace.Infrastructure.Services.Departments;
using WorkPlace.Domain;
using Npgsql;

namespace WorkPlace.Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]

    public class DepartmentController : ControllerBase
    {
        private readonly NpgsqlConnection dbconnection;

        public DepartmentController(IConfiguration configuration)
        {
            string connectionString =
                "Host=localhost;Port=5432;Database=Practice_db;Username=postgres;Password=1111";
            this.dbconnection = new NpgsqlConnection(connectionString);
        }

        [HttpGet("one-to-many")]
        public async Task<ActionResult<List<Department>>> GetAllDepartmentWithEmployeesAsync()
        {
            var departmentDictionary=new Dictionary<int, Department>();
            var selectSql =
                """
                Select * From Department d
                Join Employee e on d.Id = e.departmentId
                """;
            var result = await dbconnection.QueryAsync<Department, Employee, Department>(selectSql,
                (department, employee) =>
                {
                    if (!departmentDictionary.TryGetValue(department.Id, out var inputDepartment))
                    {
                        inputDepartment = department;
                        inputDepartment.Employees = new List<Employee>();
                        departmentDictionary[department.Id] = inputDepartment;
                    }

                    inputDepartment.Employees.Add(employee);
                    return inputDepartment;
                });
            return Ok(departmentDictionary.Values.ToList());
        }



        //     public readonly IDepartmentService departmentService;
    //
    //     public DepartmentController()
    //     {
    //         departmentService = new DepartmentService();
    //     }
    //
    //     [HttpPost]
    //     public async Task<ActionResult<Department>> PostDepartmentAsync(Department department)
    //     {
    //         var added = await departmentService.AddDepartmentAsync(department);
    //         return Ok(added);
    //     }
    //
    //     [HttpGet]
    //     public async Task<ActionResult<List<Department>>> GetDepartmentAsync()
    //     {
    //         var getting = await departmentService.GetAllDepartmentAsync();
    //         return Ok(getting);
    //     }
    //
    //     [HttpPut]
    //     public async Task<ActionResult<Department>> PutDepartmentAsync(int id,Department department)
    //     {
    //         var putting=await departmentService.UpdateDepartmentAsync( id, department );
    //         return Ok(putting);
    //     }
    //
    //     [HttpDelete]
    //     public async Task<ActionResult<Department>> DeleteDepartmentAsync(int id)
    //     {
    //         var  deleted = await departmentService.DeleteDepartmentAsync( id);
    //         return Ok("The department has been deleted");
    //     }
    //
     }
}

