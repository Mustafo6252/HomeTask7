using Microsoft.AspNetCore.Mvc;
using WorkPlace.Domain;
using WorkPlace.Infrastructure.Services.Branches;
namespace WorkPlace.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BranchController: ControllerBase
    {
        private readonly IBranchService branchService;
        public BranchController()
        {
            branchService = new BranchService();
        }

        [HttpPost]
        public async Task<ActionResult<Branch>> PostBranchAsync(Branch branch)
        {
            var addedBranch = await this.branchService.AddBranchAsync(branch);
            return Ok(addedBranch);
        }

        [HttpGet]
        public async Task<ActionResult<List<Branch>>> GetAllBranchesAsync()
        {
            var getting = await this.branchService.GetAllBranchesAsync();
            return Ok(getting);
        }

        [HttpPut]
        public async Task<ActionResult<Branch>> PutBranchAsync(int id, Branch branch)
        {
            var updated = await this.branchService.UpdateBranchAsync(id, branch);
            return Ok(updated);
        }

        [HttpDelete]
        public async Task<ActionResult<Branch>> DeleteBranchAsync(int id)
        {
            var deleted = await this.branchService.DeleteBranchAsync(id);
            return Ok("The branch has been deleted");
        }

    }
}

