using Microsoft.AspNetCore.Mvc;
using WorkPlace.Domain;

namespace WorkPlace.Infrastructure.Services.Companys;

public interface ICompanyService
{
     Task<Company> AddCompanyAsync(Company company);
     
     Task<List<Company>> GetCompaniesAsync();
     
     Task<Company> UpdateCompanyAsync(int id,Company company);
     
     Task<Company> DeleteCompanyAsync(int id);
}