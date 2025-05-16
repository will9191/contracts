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
        [Required]
        [MaxLength(120)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string CPF { get; set; } = string.Empty;
        [Required]
        public int ContractNumber { get; set; }
        [Required]
        public string Product { get; set; } = string.Empty;
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public double Value { get; set; }
        // Referência por Id ao arquivo armazenado
        // que inseriu o contrato ao banco.
        public Guid ContractFileId { get; set; }
    }
}
