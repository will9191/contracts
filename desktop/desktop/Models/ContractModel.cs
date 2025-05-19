using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace desktop.Models
{
    public class ContractModel
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("cpf")] public string CPF { get; set; }
        [JsonPropertyName("contractNumber")] public int ContractNumber { get; set; }
        [JsonPropertyName("product")] public string Product { get; set; }
        [JsonPropertyName("dueDate")] public DateTime DueDate { get; set; }
        [JsonPropertyName("value")] public double Value { get; set; }
        [JsonPropertyName("contractFileId")] public Guid ContractFileId { get; set; }
        [JsonPropertyName("createdAt")] public DateTime CreatedAt { get; set; }
    }
}
