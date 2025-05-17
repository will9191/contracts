using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Entities
{
    [Table("Contracts")]
    public class Contract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public int ContractNumber { get; set; }
        public string Product { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public double Value { get; set; }
        // Referência por Id ao arquivo armazenado
        // que inseriu o contrato ao banco.
        public Guid ContractFileId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
