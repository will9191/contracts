using server.Entities;
using server.Models;

namespace server.Mappers
{
    public class ContractMapper
    {
        // Mapeia entidades para data transfer objects
        public List<ContractResponseDto> EntitiesToDtoList(List<Contract> contractsList) {
            List<ContractResponseDto> contracts = contractsList.Select(c => new ContractResponseDto
            {
                Id = c.Id,
                Name = c.Name,
                CPF = c.CPF,
                ContractNumber = c.ContractNumber,
                Product = c.Product,
                DueDate = c.DueDate,
                Value = c.Value,
                ContractFileId = c.ContractFileId
            }).ToList();

            return contracts;
        }
    }
}
