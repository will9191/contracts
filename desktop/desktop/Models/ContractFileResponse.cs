using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace desktop.Models
{
    public class ContractFileResponse
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("filePath")]
        public string FilePath { get; set; } = string.Empty;

        [JsonPropertyName("fileName")]
        public string FileName { get; set; } = string.Empty;

        [JsonPropertyName("uploadedAt")]
        public DateTime UploadedAt { get; set; }

        [JsonPropertyName("uploadedBy")]
        public UploadedByResponse UploadedBy { get; set; } = new UploadedByResponse();
    }
}
