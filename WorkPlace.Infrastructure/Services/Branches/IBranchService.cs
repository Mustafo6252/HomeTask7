using Microsoft.AspNetCore.Mvc;
using WorkPlace.Domain;
namespace WorkPlace.Infrastructure.Services.Branches;

public interface IBranchService
{
    Task<Branch> AddBranchAsync(Branch branch);
    
    Task<List<Branch>> GetAllBranchesAsync();
    
    Task<Branch> UpdateBranchAsync(int id, Branch branch);
    
    Task<Branch> DeleteBranchAsync(int id);
}