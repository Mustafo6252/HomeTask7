using Dapper;
using Microsoft.AspNetCore.Mvc;
using WorkPlace.Domain;
using WorkPlace.Infrastructure.Services.Companys;
using Npgsql;

namespace WorkPlace.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly NpgsqlConnection dbconnection;

        public CompanyController(IConfiguration configuration)
        {
            string connectionString =
                    "Host=localhost;Port=5432;Database=Practice_db;Username=postgres;Password=1111";
            this.dbconnection = new NpgsqlConnection(connectionString);
        }

        [HttpGet("one-to-one")]
        public async Task<ActionResult<IEnumerable<Company>>> GetAllCompaniesWithBranch()
        {
            string SqlQuery =
                """
                Select * from Company c  
                Join Branch b ON c.id = b.companyId
                """;
            IEnumerable<Company> companies = await dbconnection.QueryAsync<Company,Branch,Company>(SqlQuery,
                (Company,Branch)=>
            {
                if (Company.Branches == null)
                    Company.Branches = new List<Branch>();

                Company.Branches.Add(Branch);
                return Company;
            });
            return Ok(companies);
        }

        
        [HttpGet("one-to-many")]
        public async Task<ActionResult<List<Company>>> GetAllCompanies()
        {
            var companyDictionary = new Dictionary<int, Company>();

            string SelectSql =
                """
                SELECT 
                    c.id, c.name,
                    b.id, b.location, b.companyId,
                    e.id, e.firstName, e.lastName, e.email, e.departmentId, e.branchId
                FROM Company c  
                JOIN Branch b ON c.id = b.companyId
                JOIN Employee e ON e.branchId = b.id
                """;

            var result = await dbconnection.QueryAsync<Company, Branch, Employee, Company>(
                SelectSql,
                (company, branch, employee) =>
                {
                    if (!companyDictionary.TryGetValue(company.Id, out var inputCompany))
                    {
                        inputCompany = company;
                        inputCompany.Branches = new List<Branch>();
                        companyDictionary[company.Id] = inputCompany;
                    }

                    // Branchni tekshiramiz
                    var existingBranch = inputCompany.Branches.FirstOrDefault(b => b.Id == branch.Id);
                    if (existingBranch == null)
                    {
                        branch.Employees = new List<Employee>();
                        branch.Employees.Add(employee);
                        inputCompany.Branches.Add(branch);
                    }
                    else
                    {
                        existingBranch.Employees.Add(employee);
                    }

                    return inputCompany;
                },
                splitOn: "id,id" // bu muhim: 2-chi "id" Branch uchun, 3-chi "id" Employee uchun
            );

            return Ok(companyDictionary.Values.ToList());
        }



        
        
        // [HttpGet("one-to-many")]
        // public async Task<ActionResult<List<Company>>> GetAllCompanies()
        // {
        //     var companyDictionary=new Dictionary<int, Company>();
        //     string SelectSql=
        //         """
        //         Select * from Company c  
        //         Join Branch b ON c.id = b.companyId
        //         Join Employee e on e.BranchId = b.id
        //         """;
        //     IEnumerable<Company> companies = await this.dbconnection.QueryAsync<Company, Branch,Employee, Company>(SelectSql,
        //         (Company, Branch, Employee) =>
        //         {
        //             Company inputCompany;
        //             if (companyDictionary.TryGetValue(Company.Id, out inputCompany) is false)
        //             {
        //                 inputCompany = Company;
        //                 inputCompany.Branches = new List<Branch>();
        //                 companyDictionary.Add(Company.Id, inputCompany);
        //             }
        //             
        //             
        //                 Branch.Employees = new List<Employee>();
        //               
        //
        //             inputCompany.Branches.Add(Branch);
        //             return inputCompany;
        //         });
        //     return Ok(companies.ToList().Distinct());
        // }







        // private readonly ICompanyService companyService;
        //
        // public CompanyController()
        // {
        //     this.companyService=new CompanyService();
        // }
        //
        // [HttpPost]
        // public async Task<ActionResult<Company>> PostCompanyAsync(Company company)
        // {
        //     var addedCompany=await this.companyService.AddCompanyAsync(company);
        //     return Ok(addedCompany);
        // }
        //
        // [HttpGet]
        // public async Task<ActionResult<List<Company>>> GetCompaniesAsync()
        // {
        //     var companies=await this.companyService.GetCompaniesAsync();
        //     return Ok(companies);
        // }
        //
        // [HttpPut]
        // public async Task<ActionResult<Company>> PutCompanyAsync(int id, Company company)
        // {
        //     var updatedCompany=await this.companyService.UpdateCompanyAsync(id, company);
        //     return Ok(updatedCompany);
        // }
        //
        // [HttpDelete]
        // public async Task<ActionResult<Company>> DeleteCompanyAsync(int id)
        // {
        //     var deletedCompany=await this.companyService.DeleteCompanyAsync(id);
        //     return Ok("the company was deleted");
        // }
        //
        // private readonly NpgsqlConnection npgsqlConnection;
        //
        // private const string connectionString =
        //         "Host=localhost;Port=5432;Database=Practice_db;Username=postgres;Password=1111";
        //   
        //
        //
        //     [HttpGet("Join")]
        //     public async Task<ActionResult<List<Company>>> GetAllCompanyWithBranchesAsync()
        //     {
        //         using var npgsqlConnection = new NpgsqlConnection(connectionString);
        //
        //         var selectSql = @"
        //     SELECT 
        //         c.id, c.name,
        //         b.id, b.location, b.companyId
        //     FROM Company c
        //     LEFT JOIN Branch b ON b.companyId = c.id
        // ";
        //
        //         var companyDict = new Dictionary<int, Company>();
        //
        //         var companies = await npgsqlConnection.QueryAsync<Company, Branch, Company>(
        //             selectSql,
        //             (company, branch) =>
        //             {
        //                 if (!companyDict.TryGetValue(company.Id, out var existingCompany))
        //                 {
        //                     existingCompany = company;
        //                     existingCompany.Branches = new List<Branch>();
        //                     companyDict.Add(existingCompany.Id, existingCompany);
        //                 }
        //
        //                 if (branch != null)
        //                     existingCompany.Branches.Add(branch);
        //
        //                 return existingCompany;
        //             },
        //             splitOn: "id"
        //         );
        //
        //         return Ok(companyDict.Values.ToList());
        //     }
    }
}

