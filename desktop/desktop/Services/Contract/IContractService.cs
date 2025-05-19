using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using desktop.Models;

namespace desktop.Services.Contract
{
    public interface IContractService
    {
        Task<List<ContractModel>> UploadContractsByFile(Stream fileStream, string fileName);
        Task<List<ContractModel>> GetAllPaginated(PaginateRequest request);
        Task<ContractSummaryResponse?> GetSummaryByCpfAsync(CPF request);
    }
}
