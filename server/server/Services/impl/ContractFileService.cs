
using server.Data;
using server.Entities;
using server.Models.Responses;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace server.Services.impl
{
    public class ContractFileService(AppDbContext context, IWebHostEnvironment _env) : IContractFileService
    {
        public async Task<Guid> SaveFile(IFormFile file, Guid userId)
        {
            // Verifica se o diretório existe, se não existe ele cria
            var uploadsFolder = Path.Combine(_env.ContentRootPath, "uploads", "contractfiles");
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);


            // Atribui nome único ao arquivo, para evitar sobrescrita
            var uniqueFileName = $"{Guid.NewGuid()}_{file.FileName}";

            // Direciona para o caminho dos uploads
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            var contractFile = new ContractFile
            {
                FileName = file.FileName,
                FilePath = filePath,
                UploadedAt = DateTime.UtcNow,
                UploadedBy = userId
            };

            await context.ContractFiles.AddAsync(contractFile);
            await context.SaveChangesAsync();

            return contractFile.Id;
        }

        public async Task<List<ContractFileResponseDto>> GetContractFiles(int pageNumber, int pageSize)
        {

            // Paginação para não carregar todos os arquivos de uma vez.
            // Ordena por ordem decrescente, usando a data de upload,
            // Skip Pula os arquivos já carregados e Take pega os objetos
            // de acordo com o tamanho da página
            var contractFiles = await context.ContractFiles
                .OrderByDescending(cf => cf.UploadedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var result  = new List<ContractFileResponseDto>();

            // Loop para retornar dto dos arquivos e dto de quem fez upload.
            // A consulta do user é feita pelo UploadedBy, que é o id do usuário.
            // É importante para não expor informações indesejadas,
            // por exemplo, o hash da senha.
            foreach (var cf in contractFiles)
            {
                var user = await context.Users.FindAsync(cf.UploadedBy);
                result.Add(new ContractFileResponseDto
                {
                    Id = cf.Id,
                    FileName = cf.FileName,
                    FilePath = cf.FilePath,
                    UploadedAt = cf.UploadedAt,
                    UploadedBy = user != null ? new UploadedByResponseDto
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Email = user.Email,
                        Role = user.Role
                    } : new UploadedByResponseDto { }
                });
            }

            return result;
        }

        public async Task<bool> DeleteFile(Guid fileId)
        {
            var contractFile = await context.ContractFiles.FindAsync(fileId);
            if (contractFile == null)
                return false;
            var filePath = contractFile.FilePath;
            if (File.Exists(filePath))
                File.Delete(filePath);
            context.ContractFiles.Remove(contractFile);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
