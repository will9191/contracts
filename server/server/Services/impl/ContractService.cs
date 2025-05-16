using System.Globalization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Entities;
using server.Mappers;
using server.Models;

namespace server.Services.impl
{
    public class ContractService(AppDbContext context, IContractFileService contractFileService, ContractMapper contractMapper) : IContractService
    {
      

        public async Task<List<ContractResponseDto>> saveContractsFromFile(IFormFile file, Guid userId)
        {
            var contractFileId = await contractFileService.saveFile(file, userId);

            var newContracts = new List<Contract>();

            using var stream = file.OpenReadStream();
            using var reader = new StreamReader(stream);

            int lineNumber = 0;

            while (!reader.EndOfStream)
            {
                var line = await reader.ReadLineAsync();
                lineNumber++;

                if (lineNumber == 1)
                    continue;

                var parts = line.Split(';');
                if (parts.Length != 6)
                    return null;

                newContracts.Add(new Contract
                {
                    Name = parts[0],
                    CPF = parts[1],
                    ContractNumber = int.Parse(parts[2]),
                    Product = parts[3],
                    DueDate = DateTime.Parse(parts[4], new CultureInfo("pt-br")),
                    Value = double.Parse(parts[5], CultureInfo.InvariantCulture),
                    ContractFileId = contractFileId
                });    
            }

            await context.Contracts.AddRangeAsync(newContracts);
            await context.SaveChangesAsync();


            // Mapeia retorno para DTO's
            return contractMapper.EntitiesToDtoList(newContracts);
        }

        public async Task<List<ContractResponseDto>> getAll()
        {
              List<Contract> contractsEntities = await context.Contracts.ToListAsync();

            return contractMapper.EntitiesToDtoList(contractsEntities);
        }
    }
}
