using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Entities
{
    [Table("ContractFiles")]
    public class ContractFile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string FilePath { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        // Data do upload do arquivo
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
        // Id do usuário responsável pelo
        // upload desse arquivo
        public Guid UploadedBy { get; set; }
    }
}
