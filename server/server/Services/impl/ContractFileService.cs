
using server.Data;
using server.Entities;

namespace server.Services.impl
{
    public class ContractFileService(AppDbContext context, IWebHostEnvironment _env) : IContractFileService
    {
        public async Task<Guid> saveFile(IFormFile file, Guid userId)
        {
            var uploadsFolder = Path.Combine(_env.ContentRootPath, "uploads", "contractfiles");
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var uniqueFileName = $"{Guid.NewGuid()}_{file.FileName}";
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
    }
}
