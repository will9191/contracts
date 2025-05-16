using server.Models;

namespace server.Services
{
    public interface IContractService
    {
        Task<List<ContractResponseDto>> saveContractsFromFile(IFormFile file, Guid userId);
        Task<List<ContractResponseDto>> getAll();
    }
}
