using Microsoft.AspNetCore.Mvc;
using WorkPlace.Domain;
namespace WorkPlace.Infrastructure.Services.Branches;

public interface IBranchService
{
    Task<ActionResult<Branch>> AddBranchAsync(Branch branch);
    
    Task<ActionResult<List<Branch>>> GetAllBranchesAsync();
    
    Task<ActionResult<Branch>> UpdateBranchAsync(int id, Branch branch);
    
    Task<ActionResult<Branch>> DeleteBranchAsync(int id);
}