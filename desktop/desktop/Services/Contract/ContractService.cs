using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using desktop.Models;
using desktop.Services.RequestProvider;

namespace desktop.Services.Contract
{
    public class ContractService (IRequestProvider requestProvider) : IContractService
    {
        private readonly IRequestProvider _requestProvider = requestProvider;
        public async Task<List<ContractModel>> UploadContractsByFile(Stream fileStream, string fileName)
        {
            var uri = GlobalSettings.Instance.ContractEndpoint + "/add-from-file";

            using var content = new MultipartFormDataContent();
            var fileContent = new StreamContent(fileStream);
            fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("text/csv");
            content.Add(fileContent, "file", fileName);

            return await _requestProvider.PostAsync<List<ContractModel>, MultipartFormDataContent>(uri, content);
        }

        public async Task<List<ContractModel>> GetAllPaginated(PaginateRequest request)
        {
            var uri = GlobalSettings.Instance.ContractEndpoint + "/get-all-paginated";
           
            return await _requestProvider.GetAsync<List<ContractModel>, PaginateRequest>(uri, request);
        }

        public async Task<ContractSummaryResponse?> GetSummaryByCpfAsync(CPF request)
        {
            var uri = GlobalSettings.Instance.ContractEndpoint + "/summary-by-cpf";

            return await _requestProvider.GetAsync<ContractSummaryResponse, CPF>(uri, request);
        }
    }
}
