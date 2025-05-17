using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.Models.Responses;
using server.Services;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractController(IContractService contractService, IUserContextService userContextService) : ControllerBase
    {
        [HttpPost("add-from-file")]
        public async Task<ActionResult<List<ContractResponseDto>>> ImportContract(IFormFile file)
        {
            Guid userId = userContextService.GetUserId(User);

            var contracts = await contractService.SaveContractsFromFile(file, userId);

            return Ok(contracts);
        }
       


        [HttpGet("get-all-paginated")]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult<List<ContractResponseDto>>> GetContractsPaginated(int pageNumber = 1, int pageSize = 10)
        {
            if (pageNumber <= 0)
                return BadRequest("Page Number must be greater than 0.");

            var contracts = await contractService.GetContracts(pageNumber, pageSize);

            return Ok(contracts);
        }

        [HttpGet("summary-by-cpf")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<ActionResult<ContractSummaryResponseDto>> GetContractsByCPF(string CPF)
        {

            var summary = await contractService.GetContractsSummaryByCPF(CPF);

            if (summary is null)
            {
                return NotFound("No contracts found for this CPF.");
            }

            return Ok(summary);
        }
    }
}
