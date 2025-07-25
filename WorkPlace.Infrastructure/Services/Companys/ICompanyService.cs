using Microsoft.AspNetCore.Mvc;
using WorkPlace.Domain;

namespace WorkPlace.Infrastructure.Services.Companys;

public interface ICompanyService
{
     Task<ActionResult<Company>> AddCompanyAsync(Company company);
     
     Task<ActionResult<List<Company>>> GetCompaniesAsync();
     
     Task<ActionResult<Company>> UpdateCompanyAsync(int id,Company company);
     
     Task<ActionResult<Company>> DeleteCompanyAsync(int id);
}