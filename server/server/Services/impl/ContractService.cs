﻿using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Entities;
using server.Mappers;
using server.Models.Responses;

namespace server.Services.impl
{
    public class ContractService(AppDbContext context, IContractFileService contractFileService, ContractMapper contractMapper) : IContractService
    {
        public async Task<List<ContractResponseDto>> SaveContractsFromFile(IFormFile file, Guid userId)
        {
            var contractFileId = await contractFileService.SaveFile(file, userId);

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
                    ContractFileId = contractFileId,
                    CreatedAt = DateTime.UtcNow
                });    
            }

            await context.Contracts.AddRangeAsync(newContracts);
            await context.SaveChangesAsync();


            // Mapeia retorno para DTO's
            return contractMapper.EntitiesToDtoList(newContracts);
        }

        public async Task<List<ContractResponseDto>> GetContracts(int pageNumber, int pageSize)
        {
            List<Contract> contractsEntities = await context.Contracts
                .OrderByDescending(c => c.CreatedAt)
                .Skip((pageNumber - 1 < 0 ? 0 : pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return contractMapper.EntitiesToDtoList(contractsEntities);
        }

        public async Task<ContractSummaryResponseDto> GetContractsSummaryByCPF(string CPF)
        {
            List<Contract> contracts = await context.Contracts
                .Where(c => c.CPF == CPF)
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();

            if (contracts is null) 
                return null;

            var contractsDetails = contracts.Select(c => new ContractDetailsResponseDto
            {
                ContractNumber = c.ContractNumber,
                Product = c.Product,
                DueDate = c.DueDate,
                Value = c.Value
            }).ToList();

            var totalValue = contracts.Sum(c => c.Value);

            var today = DateTime.UtcNow.Date;

            var maxDelayDays = contracts
                .Where(c => c.DueDate.Date < today)
                .Select(c => (today - c.DueDate.Date).Days)
                .DefaultIfEmpty(0)
                .Max();

            return new ContractSummaryResponseDto
            {
                Name = contracts.FirstOrDefault()?.Name ?? string.Empty,
                CPF = CPF,
                Contracts = contractsDetails,
                TotalValue = totalValue,
                MaxDelayDays = maxDelayDays
            };
        }
    }
}
