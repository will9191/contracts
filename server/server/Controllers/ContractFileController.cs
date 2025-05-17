using Microsoft.AspNetCore.Mvc;
using server.Services;
using server.Models.Responses;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractFileController (IContractFileService contractFileService) : ControllerBase
    {
        [HttpGet("get-all-paginated")]
        public async Task<ActionResult<List<ContractFileResponseDto>>> GetFilesPaginated(int pageNumber = 1, int pageSize = 10)
        {
            var files = await contractFileService.GetContractFiles(pageNumber, pageSize);
            return Ok(files);
        }
    }
}
