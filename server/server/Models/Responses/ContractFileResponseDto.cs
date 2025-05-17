using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models.Responses
{
    public class ContractFileResponseDto
    {
        public Guid Id { get; set; }
        public string FilePath { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public DateTime UploadedAt { get; set; }
        public UploadedByResponseDto UploadedBy { get; set; } = new UploadedByResponseDto();
    }
}
