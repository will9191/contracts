using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models
{
    public class ContractResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public int ContractNumber { get; set; }    
        public string Product { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public double Value { get; set; }
        public Guid ContractFileId { get; set; }
    }
}
