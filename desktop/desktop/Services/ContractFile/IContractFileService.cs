using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using desktop.Models;

namespace desktop.Services.ContractFile
{
    public interface IContractFileService
    {
        Task<List<ContractFileResponse>> GetImportedFilesAsync(PaginateRequest request);
    }
}
