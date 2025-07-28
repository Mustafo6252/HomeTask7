using Dapper;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using WorkPlace.Domain;
using WorkPlace.Infrastructure.Services.Branches;
namespace WorkPlace.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BranchController: ControllerBase
    {
        public readonly NpgsqlConnection connection;

        public BranchController(IConfiguration configuration)
        {
            string connectionString =
                "Host=localhost;Port=5432;Database=Practice_db;Username=postgres;Password=1111";
            this.connection = new NpgsqlConnection(connectionString);
        }

        [HttpGet("one-to-many")]
        public async Task<ActionResult<List<Branch>>> GetAllBranchesWithEmployees()
        {
            var branchDictionary=new Dictionary<int, Branch>();
            var selectSql =
                """
                Select * from branch b
                Join Employee e on e.branchId = b.Id
                """;
            var result = await connection.QueryAsync<Branch, Employee, Branch>(selectSql,
                (branch, employee) =>
                {
                    if (!branchDictionary.TryGetValue(branch.Id, out var inputBranch))
                    {
                        inputBranch = branch;
                        inputBranch.Employees = new List<Employee>();
                        branchDictionary[branch.Id] = inputBranch;
                    }

                    inputBranch.Employees.Add(employee);
                    return inputBranch;
                });
            return Ok(branchDictionary.Values.ToList());
        }



        // private readonly IBranchService branchService;
        // public BranchController()
        // {
        //     branchService = new BranchService();
        // }
        //
        // [HttpPost]
        // public async Task<ActionResult<Branch>> PostBranchAsync(Branch branch)
        // {
        //     var addedBranch = await this.branchService.AddBranchAsync(branch);
        //     return Ok(addedBranch);
        // }
        //
        // [HttpGet]
        // public async Task<ActionResult<List<Branch>>> GetAllBranchesAsync()
        // {
        //     var getting = await this.branchService.GetAllBranchesAsync();
        //     return Ok(getting);
        // }
        //
        // [HttpPut]
        // public async Task<ActionResult<Branch>> PutBranchAsync(int id, Branch branch)
        // {
        //     var updated = await this.branchService.UpdateBranchAsync(id, branch);
        //     return Ok(updated);
        // }
        //
        // [HttpDelete]
        // public async Task<ActionResult<Branch>> DeleteBranchAsync(int id)
        // {
        //     var deleted = await this.branchService.DeleteBranchAsync(id);
        //     return Ok("The branch has been deleted");
        // }

    }
}

