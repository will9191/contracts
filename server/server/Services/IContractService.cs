using Microsoft.AspNetCore.Mvc;
using server.Models.Responses;

namespace server.Services
{
    public interface IContractService
    {
        Task<List<ContractResponseDto>> SaveContractsFromFile(IFormFile file, Guid userId);
        Task<List<ContractResponseDto>> GetContracts(int pageNumber, int pageSize);
        Task<ContractSummaryResponseDto> GetContractsSummaryByCPF(string CPF);
    }
}
