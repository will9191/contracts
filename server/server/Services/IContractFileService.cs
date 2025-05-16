namespace server.Services
{
    public interface IContractFileService
    {
        Task<Guid> saveFile(IFormFile file, Guid userId);
    }
}
