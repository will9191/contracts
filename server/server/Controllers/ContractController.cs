using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using server.Entities;
using server.Models;
using server.Services;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractController(IContractService contractService, ILogger<ContractController> _logger) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<List<ContractResponseDto>>> ImportContract(IFormFile file)
        {
            var userIdStr= User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userIdStr == null)
                throw new Exception("Usuário não autenticado.");

            Guid userId = Guid.Parse(userIdStr);

            // Log do Id extraído do usuário
            _logger.LogInformation("UserId extraído do token: {UserId}", userId);

            var contracts = await contractService.saveContractsFromFile(file, userId);

            return contracts;
        }
       


        [HttpGet]
        public ActionResult Get()
        {
            return contractService.
        }
    }
}
