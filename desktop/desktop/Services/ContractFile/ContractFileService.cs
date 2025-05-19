using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using desktop.Models;
using desktop.Services.RequestProvider;

namespace desktop.Services.ContractFile
{
    public class ContractFileService (IRequestProvider requestProvider) : IContractFileService
    {
        private readonly IRequestProvider _requestProvider = requestProvider;
        public async Task<List<ContractFileResponse>> GetImportedFilesAsync(PaginateRequest request)
        {
            var uri = GlobalSettings.Instance.ContractFileEndpoint + "/get-all-paginated"; // ajuste o endpoint conforme sua API
            return await _requestProvider.GetAsync<List<ContractFileResponse>, PaginateRequest>(uri, request);
        }
    }
}
