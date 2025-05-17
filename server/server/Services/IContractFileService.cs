using Microsoft.AspNetCore.Mvc;
using server.Models.Responses;

namespace server.Services
{
    public interface IContractFileService
    {
        Task<Guid> SaveFile(IFormFile file, Guid userId);
        Task<List<ContractFileResponseDto>> GetContractFiles(int pageNumber, int pageSize);
    }
}
