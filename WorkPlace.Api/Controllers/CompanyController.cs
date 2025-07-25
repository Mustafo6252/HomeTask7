using Microsoft.AspNetCore.Mvc;
using WorkPlace.Domain;
using WorkPlace.Infrastructure.Services.Companys;

namespace WorkPlace.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController: ControllerBase
    {
        private readonly ICompanyService companyService;

        public CompanyController()
        {
            this.companyService=new CompanyService();
        }

        [HttpPost]
        public async Task<ActionResult<Company>> PostCompanyAsync(Company company)
        {
            var addedCompany=await this.companyService.AddCompanyAsync(company);
            return Ok(addedCompany);
        }

        [HttpGet]
        public async Task<ActionResult<List<Company>>> GetCompaniesAsync()
        {
            var companies=await this.companyService.GetCompaniesAsync();
            return Ok(companies);
        }

        [HttpPut]
        public async Task<ActionResult<Company>> PutCompanyAsync(int id, Company company)
        {
            var updatedCompany=await this.companyService.UpdateCompanyAsync(id, company);
            return Ok(updatedCompany);
        }

        [HttpDelete]
        public async Task<ActionResult<Company>> DeleteCompanyAsync(int id)
        {
            var deletedCompany=await this.companyService.DeleteCompanyAsync(id);
            return Ok("the company was deleted");
        }
        
    }
}

